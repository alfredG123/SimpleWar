using UnityEngine;

public class ProjectileObject : MonoBehaviour
{
    // Properties
    private GameObject _target = null;
    private float _speed = 5f;

    /// <summary>
    /// Move the projectile to the target position
    /// </summary>
    private void FixedUpdate()
    {
        Vector3 direction = (_target.transform.position - this.transform.position).normalized;

        transform.position += direction * _speed * Time.deltaTime;

        transform.eulerAngles = new Vector3(0, 0, GeneralMethods.ConvertDirectionToAngle(direction));

        if (!BattleManager.CheckIfMinionExists(_target.GetComponent<Minion>()))
        {
            Destroy(this.gameObject);
        }
        else
        {
            if (Vector3.Distance(_target.transform.position, this.transform.position) <= 0.3f)
            {
                _target.GetComponent<Minion>().TakeDamage(5);

                Destroy(this.gameObject);
            }
        }
    }

    /// <summary>
    /// Select the taget
    /// </summary>
    /// <param name="target"></param>
    private void SelectTargetAndFire(GameObject target)
    {
        _target = target;
    }

    #region Static
    /// <summary>
    /// Create a projectile object, and move it to the target
    /// </summary>
    /// <param name="spawn_position"></param>
    /// <param name="target"></param>
    public static void FireProjectile(Vector3 spawn_position, GameObject target)
    {
        GameObject projectile = Instantiate(GameObjectCreator.Creator.Projectile, spawn_position, Quaternion.identity);

        ProjectileObject project_object = projectile.GetComponent<ProjectileObject>();
        project_object.SelectTargetAndFire(target);
    }
    #endregion
}
