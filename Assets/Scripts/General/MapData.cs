using UnityEngine;

public class MapData : MonoBehaviour
{
    // Texts
    public TextAsset Map1 = null;

    #region Static
    // Properties
    private static MapData _creator = null;

    /// <summary>
    /// Return a creator for prefabs
    /// </summary>
    public static MapData Creator
    {
        get
        {
            if (_creator == null)
            {
                _creator = (Instantiate(Resources.Load("MapData")) as GameObject).GetComponent<MapData>();
            }

            return _creator;
        }
    }
    #endregion
}
