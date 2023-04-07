using UnityEngine;

public class ProjectileObject : MonoBehaviour
{
    // Properties
    private BattleObject _target_object = null;
    private float _speed = 5f;

    /// <summary>
    /// Move the projectile to the target position
    /// </summary>
    private void Update()
    {
        Vector3 direction = (_target_object.transform.position - this.transform.position).normalized;

        transform.position += direction * _speed * Time.deltaTime;

        transform.eulerAngles = new Vector3(0, 0, GeneralMethods.ConvertDirectionToAngle(direction));

        if (!BattleManager.CheckIfObjectExists(_target_object))
        {
            Destroy(this.gameObject);
        }
        else
        {
            if (Vector3.Distance(_target_object.transform.position, this.transform.position) <= 0.3f)
            {
                _target_object.TakeDamage(5);

                Destroy(this.gameObject);
            }
        }
    }

    /// <summary>
    /// Set up the target that the projectile is heading to
    /// </summary>
    /// <param name="target_object"></param>
    private void StartFire(BattleObject target_object)
    {
        _target_object = target_object;
    }

    #region Static
    /// <summary>
    /// Create a projectile object, and move it to the target
    /// </summary>
    /// <param name="spawn_position"></param>
    /// <param name="target_object"></param>
    public static void FireProjectile(Vector3 spawn_position, BattleObject target_object)
    {
        GameObject projectile = Instantiate(GameObjectCreator.Creator.Projectile, spawn_position, Quaternion.identity);

        ProjectileObject project_object = projectile.GetComponent<ProjectileObject>();
        project_object.StartFire(target_object);
    }
    #endregion
}
