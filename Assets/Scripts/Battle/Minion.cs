using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    // Minion list
    private static List<GameObject> _enemy_list = new List<GameObject>();
    private static List<GameObject> _ally_list = new List<GameObject>();

    // Minion properties
    private float _speed = 5f;
    private float _attack_range = 1.5f;

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

    // Update is called once per frame
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
            
        }
    }

    // Move the current minion
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

    // Select the nearest game object that is an enemy
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

    // Find the nearest enemy
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
