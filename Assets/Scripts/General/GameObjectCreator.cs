using UnityEngine;

public class GameObjectCreator : MonoBehaviour
{
    // Prebfab
    public GameObject ProjectileObject = null;

    #region Static
    // Creator
    private static GameObjectCreator _creator = null;

    /// <summary>
    /// Return the creator for the prefab
    /// </summary>
    public static GameObjectCreator Creator
    {
        get
        {
            // Create the creator
            if (_creator == null)
            {
                _creator = (Instantiate(Resources.Load("GameObjectCreator")) as GameObject).GetComponent<GameObjectCreator>();
            }
            
            return _creator;
        }
    }
    #endregion
}
