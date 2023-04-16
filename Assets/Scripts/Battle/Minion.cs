using System;
using UnityEngine;

public class Minion : BattleObject
{
    // Minion properties
    private GameObject _fire_location = null;

    // Minion stats
    private float _speed = 5f;
    private float _attack_speed = 2f;
    private float _attack_range = 5f;

    // Timer
    private float _attack_timer = 0f;

    #region Static
    /// <summary>
    /// Create a minion object
    /// </summary>
    /// <param name="spawn_position"></param>
    /// <param name="minion_team"></param>
    public static void SpawnMinion(Vector3 spawn_position, BattleObject.ObjectTeam minion_team)
    {
        GameObject minion_object = Instantiate(GameObjectCreator.Creator.Minion, spawn_position, Quaternion.identity);

        Minion Minion = minion_object.GetComponent<Minion>();
        Minion.SetupMinion(minion_team);
    }
    #endregion

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        // Select an enemy to attack
        BattleObject enemy = BattleManager.GetNearestEnemy(this, _attack_range);

        Move();

        // If there is a target, attack it
        if (enemy != null)
        {
            if (_attack_timer <= 0)
            {
                ProjectileObject.FireProjectile(_fire_location.transform.position, enemy);

                _attack_timer = _attack_speed;
            }
        }

        _attack_timer -= Time.deltaTime;
    }

    /// <summary>
    /// Move the current minion
    /// </summary>
    private void Move()
    {
        Vector3 direction;

        // Determine the direction
        if (this.Team == ObjectTeam.Bot)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }

        // Move the minion toward to target direction
        if (CheckIfCanMove(direction))
        {
            transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);
        }
    }

    /// <summary>
    /// Check if the character can move toward the specified direction
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    private bool CheckIfCanMove(Vector3 direction)
    {
        return (!Physics.Raycast(transform.position, direction, 1f));
    }

    /// <summary>
    /// Set up the minion properties
    /// </summary>
    /// <param name="minion_team"></param>
    private void SetupMinion(BattleObject.ObjectTeam minion_team)
    {
        _fire_location = this.gameObject.transform.Find("FireLocation").gameObject;
        this.Team = minion_team;
        this.Health = 10;

        BattleManager.RegisterObject(this);
    }
}
