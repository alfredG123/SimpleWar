using UnityEngine;

public class MinionsSpawn : MonoBehaviour
{
    public GameObject MinionPrefab = null;
    public string MinionTag = null;

    // Spawn properties
    private float _spawn_interval = 10f;
    private float _spawn_timer = 0f;

    // Update is called once per frame
    private void Update()
    {
        _spawn_timer += Time.deltaTime;

        // Spawn minions
        if (_spawn_timer > _spawn_interval)
        {
            SpawnMinion();

            _spawn_timer -= _spawn_interval;
        }
    }

    // Spawn a minion
    private void SpawnMinion()
    {
        // Create and set up a minion
        GameObject minion_prefab = MinionPrefab;
        minion_prefab.tag = MinionTag;

        // Create the game object
        Instantiate(minion_prefab, this.gameObject.transform.position, Quaternion.identity);
    }
}
