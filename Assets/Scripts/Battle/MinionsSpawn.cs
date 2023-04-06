using UnityEngine;

public class MinionsSpawn : MonoBehaviour
{
    public GameObject SpawnLocation = null;

    public void SpawnMinion()
    {
        Minion.SpawnMinion(SpawnLocation.transform.position, Minion.MinionCamp.Player);
    }
}
