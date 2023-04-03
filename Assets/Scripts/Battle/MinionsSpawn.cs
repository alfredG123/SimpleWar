using UnityEngine;

public class MinionsSpawn : MonoBehaviour
{
    public GameObject MinionPrefab = null;
    public string MinionTag = null;

    private float _spawn_interval = 5;
    private float timer = 0;

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > _spawn_interval)
        {
            SpawnMinion();

            timer -= _spawn_interval;
        }
    }

    // Spawn a minion
    private void SpawnMinion()
    {
        GameObject minion = Instantiate(MinionPrefab, this.gameObject.transform.position, Quaternion.identity);
        minion.tag = MinionTag;
    }
}
