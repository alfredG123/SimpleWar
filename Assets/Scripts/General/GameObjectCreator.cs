using UnityEngine;

public class GameObjectCreator : MonoBehaviour
{
    // Prefabs
    public GameObject Projectile = null;
    public GameObject Minion = null;
    public GameObject MapCell = null;

    #region Static
    // Properties
    private static GameObjectCreator _creator = null;

    /// <summary>
    /// Return a creator for prefabs
    /// </summary>
    public static GameObjectCreator Creator
    {
        get
        {
            if (_creator == null)
            {
                _creator = (Instantiate(Resources.Load("GameObjectCreator")) as GameObject).GetComponent<GameObjectCreator>();
            }
            
            return _creator;
        }
    }
    #endregion
}
