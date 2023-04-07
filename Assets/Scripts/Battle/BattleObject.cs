using UnityEngine;

public abstract class BattleObject : MonoBehaviour
{
    // Team of the object
    public enum ObjectTeam
    {
        Player,
        Bot,
    }

    // Properties
    private ObjectTeam _team;
    private float _health;

    #region Properties
    /// <summary>
    /// Return the team of the object
    /// </summary>
    public ObjectTeam Team
    {
        get
        {
            return _team;
        }
        protected set
        {
            _team = value;
        }
    }
    
    /// <summary>
    /// Return the health of the object
    /// </summary>
    protected float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }
    #endregion

    /// <summary>
    /// Deduct the health point from the enemy
    /// </summary>
    /// <param name="damage_amount"></param>
    public void TakeDamage(float damage_amount)
    {
        _health -= damage_amount;

        // If the minion has no health, destory it
        if (_health <= 0f)
        {
            BattleManager.DeregisterObject(this);

            Destroy(this.gameObject);
        }
    }
}
