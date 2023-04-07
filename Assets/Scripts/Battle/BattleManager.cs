using System.Collections.Generic;
using UnityEngine;

public static class BattleManager
{
    // Game object list
    private static readonly Dictionary<int, BattleObject> _player_object_list = new();
    private static readonly Dictionary<int, BattleObject> _bot_object_list = new();

    /// <summary>
    /// Store the game object for later reference
    /// </summary>
    /// <param name="battle_object"></param>
    public static void RegisterObject(BattleObject battle_object)
    {
        GetList(battle_object).Add(battle_object.GetInstanceID(), battle_object);
    }

    /// <summary>
    /// Remove the reference of the game object
    /// </summary>
    /// <param name="battle_object"></param>
    public static void DeregisterObject(BattleObject battle_object)
    {
        GetList(battle_object).Remove(battle_object.GetInstanceID());
    }

    /// <summary>
    /// Check if the game object still exits
    /// </summary>
    /// <param name="battle_object"></param>
    /// <returns></returns>
    public static bool CheckIfMinionExists(BattleObject battle_object)
    {
        return (GetList(battle_object).ContainsKey(battle_object.GetInstanceID()));
    }

    /// <summary>
    /// Select the nearest game object that is an enemy
    /// </summary>
    /// <param name="battle_object"></param>
    /// <param name="range"></param>
    /// <returns></returns>
    public static BattleObject GetNearestEnemy(BattleObject battle_object, float range)
    {
        return GetNearestObject(battle_object, range);
    }

    /// <summary>
    /// Return the related list for the game object
    /// </summary>
    /// <param name="battle_object"></param>
    /// <returns></returns>
    private static Dictionary<int, BattleObject> GetList(BattleObject battle_object)
    {
        Dictionary<int, BattleObject> object_list;

        if (battle_object.Team == BattleObject.ObjectTeam.Player)
        {
            object_list = _player_object_list;
        }
        else
        {
            object_list = _bot_object_list;
        }

        return object_list;
    }

    /// <summary>
    /// Return the enemy list for the minion
    /// </summary>
    /// <param name="battle_object"></param>
    /// <returns></returns>
    private static Dictionary<int, BattleObject> GetEnemyList(BattleObject battle_object)
    {
        Dictionary<int, BattleObject> object_list;

        if (battle_object.Team == BattleObject.ObjectTeam.Player)
        {
            object_list = _bot_object_list;
        }
        else
        {
            object_list = _player_object_list;
        }

        return object_list;
    }

    /// <summary>
    /// Find the nearest enemy
    /// </summary>
    /// <param name="battle_object"></param>
    /// <param name="range"></param>
    /// <returns></returns>
    private static BattleObject GetNearestObject(BattleObject battle_object, float range)
    {
        BattleObject nearest_object = null;
        Dictionary<int, BattleObject> enemy_object_list = GetEnemyList(battle_object);
        float nearest_distance = 0f;

        foreach (BattleObject enemy_object in enemy_object_list.Values)
        {
            float distance = Vector3.Distance(battle_object.transform.position, enemy_object.transform.position);

            if (distance <= range)
            {
                if (nearest_object == null)
                {
                    nearest_object = enemy_object;
                }
                else
                {
                    if (distance < nearest_distance)
                    {
                        nearest_object = enemy_object;
                        nearest_distance = distance;
                    }
                }
            }
        }

        return nearest_object;
    }
}
