using UnityEngine;

public class Castle : MonoBehaviour
{
    public Minion.MinionCamp Camp = Minion.MinionCamp.Bot;

    private GameObject _spawn_location = null;
    private float _spawn_timer = 0f;
    private float _spawn_interval = 5f;

    private void Awake()
    {
        _spawn_location = gameObject.transform.Find("Spawn Location").gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        _spawn_timer += Time.deltaTime;

        // Spawn minions
        if (_spawn_timer > _spawn_interval)
        {
            Minion.SpawnMinion(_spawn_location.transform.position, Camp);

            _spawn_timer -= _spawn_interval;
        }
    }
}
