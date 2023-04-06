using System;
using UnityEngine;

public class Minion : MonoBehaviour
{
    public enum MinionCamp
    {
        Player,
        Bot,
    }

    // Minion properties
    private string _unique_id = string.Empty;
    private MinionCamp _minion_camp = MinionCamp.Player;
    private GameObject _fire_location = null;

    // Minion stats
    private float _health = 10f;
    private float _speed = 5f;
    private float _attack_speed = 2f;
    private float _attack_range = 5f;

    // Timer
    private float _attack_timer = 0f;

    #region Properties
    /// <summary>
    /// Return the identifier of the minion
    /// </summary>
    public string UniqueID
    {
        get
        {
            return _unique_id;
        }
    }

    /// <summary>
    /// Return the camp of the minion
    /// </summary>
    public MinionCamp Camp
    {
        get
        {
            return _minion_camp;
        }
    }

    /// <summary>
    /// Return the attack range of the minion
    /// </summary>
    public float AttackRange
    {
        get
        {
            return _attack_range;
        }
    }
    #endregion

    #region Static
    /// <summary>
    /// Create a minion object
    /// </summary>
    /// <param name="spawn_position"></param>
    /// <param name="minion_camp"></param>
    public static void SpawnMinion(Vector3 spawn_position, MinionCamp minion_camp)
    {
        GameObject minion_object = Instantiate(GameObjectCreator.Creator.Minion, spawn_position, Quaternion.identity);

        Minion Minion = minion_object.GetComponent<Minion>();
        Minion.SetupMinion(minion_camp);
    }
    #endregion

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void FixedUpdate()
    {
        // Select an enemy to attack
        GameObject enemy = BattleManager.GetNearestEnemy(this);

        // If there are no targets, move forward
        if (enemy == null)
        {
            Move();
        }

        // If there is a target, attack it
        else
        {
            if (_attack_timer <= 0)
            {
                ProjectileObject.FireProjectile(_fire_location.transform.position, enemy);

                _attack_timer = _attack_speed;
            }

            _attack_timer -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Deduct the health point from the enemy
    /// </summary>
    /// <param name="damage_amount"></param>
    public void TakeDamage(float damage_amount)
    {
        _health -= damage_amount;

        // If the minion has no health, destory it
        if (_health <= 0f)
        {
           BattleManager.DeregisterMinion(this);

           Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Move the current minion
    /// </summary>
    private void Move()
    {
        Vector3 direction;

        // Determine the direction
        if (_minion_camp == MinionCamp.Bot)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }

        // Move the minion toward to target direction
        transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);
    }

    /// <summary>
    /// Set up the minion properties
    /// </summary>
    /// <param name="minion_camp"></param>
    private void SetupMinion(MinionCamp minion_camp)
    {
        _unique_id = Guid.NewGuid().ToString();
        _fire_location = this.gameObject.transform.Find("FireLocation").gameObject;
        _minion_camp = minion_camp;

        BattleManager.RegisterMinion(this);
    }
}
