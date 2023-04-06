using System.Collections.Generic;
using UnityEngine;

public static class BattleManager
{
    // Minion list
    private static Dictionary<string, Minion> _player_minion_list = new Dictionary<string, Minion>();
    private static Dictionary<string, Minion> _bot_minion_list = new Dictionary<string, Minion>();

    /// <summary>
    /// Store the minion
    /// </summary>
    /// <param name="minion"></param>
    public static void RegisterMinion(Minion minion)
    {
        GetList(minion).Add(minion.UniqueID, minion);
    }

    /// <summary>
    /// Remove the minion
    /// </summary>
    /// <param name="minion_object"></param>
    public static void DeregisterMinion(Minion minion)
    {
        GetList(minion).Remove(minion.UniqueID);
    }

    /// <summary>
    /// Check if the minion still exits
    /// </summary>
    /// <param name="minion_object"></param>
    /// <returns></returns>
    public static bool CheckIfMinionExists(Minion minion)
    {
        return (GetList(minion).ContainsKey(minion.UniqueID));
    }

    /// <summary>
    /// Select the nearest game object that is an enemy
    /// </summary>
    /// <param name="minion_object"></param>
    /// <returns></returns>
    public static GameObject GetNearestEnemy(Minion minion)
    {
        return GetNearestObject(minion);
    }

    /// <summary>
    /// Return the related list for the minion
    /// </summary>
    /// <param name="minion"></param>
    /// <returns></returns>
    private static Dictionary<string, Minion> GetList(Minion minion)
    {
        Dictionary<string, Minion> minion_list;

        if (minion.Camp == Minion.MinionCamp.Player)
        {
            minion_list = _player_minion_list;
        }
        else
        {
            minion_list = _bot_minion_list;
        }

        return minion_list;
    }

    /// <summary>
    /// Return the enemy list for the minion
    /// </summary>
    /// <param name="minion"></param>
    /// <returns></returns>
    private static Dictionary<string, Minion> GetEnemyList(Minion minion)
    {
        Dictionary<string, Minion> minion_list;

        if (minion.Camp == Minion.MinionCamp.Player)
        {
            minion_list = _bot_minion_list;
        }
        else
        {
            minion_list = _player_minion_list;
        }

        return minion_list;
    }

    /// <summary>
    /// Find the nearest enemy
    /// </summary>
    /// <param name="minion"></param>
    /// <returns></returns>
    private static GameObject GetNearestObject(Minion minion)
    {
        GameObject nearest_object = null;
        Dictionary<string, Minion> enemy_minion_list = GetEnemyList(minion);
        float nearest_distance = 0f;

        foreach (Minion enemy_minion in enemy_minion_list.Values)
        {
            float distance = Vector3.Distance(minion.gameObject.transform.position, enemy_minion.transform.position);

            if (distance <= minion.AttackRange)
            {
                if (nearest_object == null)
                {
                    nearest_object = enemy_minion.gameObject;
                }
                else
                {
                    if (distance < nearest_distance)
                    {
                        nearest_object = enemy_minion.gameObject;
                        nearest_distance = distance;
                    }
                }
            }
        }

        return nearest_object;
    }
}
