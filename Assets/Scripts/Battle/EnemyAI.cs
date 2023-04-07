using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Position where the minion is placed after it is created
    private GameObject _spawn_location = null;

    // Properties for spawning minions
    private float _spawn_timer = 0f;
    private float _spawn_interval = 5f;

    private void Awake()
    {
        // Find the game object that is the reference of the spawn location
        _spawn_location = gameObject.transform.Find("Spawn Location").gameObject;
    }

    private void Update()
    {
        _spawn_timer += Time.deltaTime;

        // Spawn minion
        if (_spawn_timer > _spawn_interval)
        {
            Minion.SpawnMinion(_spawn_location.transform.position, BattleObject.ObjectTeam.Bot);

            _spawn_timer -= _spawn_interval;
        }
    }
}
