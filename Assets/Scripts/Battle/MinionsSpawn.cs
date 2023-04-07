using UnityEngine;

public class MinionsSpawn : MonoBehaviour
{
    // Position where the minion is placed after it is created
    public GameObject SpawnLocation = null;

    /// <summary>
    /// Create a minion at the spawn location for the player
    /// </summary>
    public void SpawnMinion()
    {
        Minion.SpawnMinion(SpawnLocation.transform.position, BattleObject.ObjectTeam.Player);
    }
}
