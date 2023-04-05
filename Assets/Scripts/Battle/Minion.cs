using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    public GameObject FireLocation = null;

    // Minion list
    private static List<GameObject> _enemy_list = new List<GameObject>();
    private static List<GameObject> _ally_list = new List<GameObject>();

    // Minion properties
    private float _health = 10f;
    private float _speed = 5f;
    private float _attack_speed = 2f;
    private float _attack_range = 5f;
    private bool _is_destory = false;

    // Timer
    private float _attack_timer = 0f;

    /// <summary>
    /// Set up the minion
    /// </summary>
    private void Awake()
    {
        // Store the minion
        if (this.tag == GameObjectTag.Ally)
        {
            _ally_list.Add(this.gameObject);
        }
        else
        {
            _enemy_list.Add(this.gameObject);
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void FixedUpdate()
    {
        // Select an enemy to attack
        GameObject enemy = GetNearestEnemy();

        // If there are no targets, move forward
        if (enemy == null)
        {
            Move();
        }

        // If there is a target, attack it
        else
        {
            _attack_timer += Time.deltaTime;

            if (_attack_timer > _attack_speed)
            {
                ProjectileObject.FireProjectile(FireLocation.transform.position, enemy);

                _attack_timer -= _attack_speed;
            }
        }
    }

    /// <summary>
    /// Deduct the health point
    /// </summary>
    /// <param name="damage_amount"></param>
    public void TakeDamage(float damage_amount)
    {
        _health -= damage_amount;

        if (_health <= 0f)
        {
            // Remove the current object
            if (this.tag == GameObjectTag.Ally)
            {
                _ally_list.Remove(this.gameObject);
            }
            else
            {
                _enemy_list.Remove(this.gameObject);
            }

            _is_destory = true;

           Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Return if the game object is destory
    /// </summary>
    /// <returns></returns>
    public bool IsDestory()
    {
        return _is_destory;
    }

    /// <summary>
    /// Move the current minion
    /// </summary>
    private void Move()
    {
        Vector3 direction;

        // Determine the direction
        if (this.tag == GameObjectTag.Ally)
        {
            direction = Vector3.left;
        }
        else
        {
            direction = Vector3.right;
        }

        // Move the minion toward to target direction
        transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);
    }

    /// <summary>
    /// Select the nearest game object that is an enemy
    /// </summary>
    /// <returns></returns>
    private GameObject GetNearestEnemy()
    {
        List<GameObject> enemy_list;
        GameObject nearest_enemy;
 
        // Get the enemy list
        if (this.tag == GameObjectTag.Ally)
        {
            enemy_list = _enemy_list;
        }
        else
        {
            enemy_list = _ally_list;
        }

        nearest_enemy = GetNearestObject(enemy_list, _attack_range);

        return nearest_enemy;
    }

    /// <summary>
    /// Find the nearest enemy
    /// </summary>
    /// <param name="object_list"></param>
    /// <param name="range"></param>
    /// <returns></returns>
    private GameObject GetNearestObject(List<GameObject> object_list, float range)
    {
        GameObject nearest_object = null;
        float nearest_distance = 0f;

        foreach (GameObject game_object in object_list)
        {
            float distance = Vector3.Distance(this.gameObject.transform.position, game_object.transform.position);

            if (distance <= range)
            {
                if (nearest_object == null)
                {
                    nearest_object = game_object;
                }
                else
                {
                    if (distance < nearest_distance)
                    {
                        nearest_object = game_object;
                        nearest_distance = distance;
                    }
                }
            }
        }

        return nearest_object;
    }
}
