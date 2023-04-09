using UnityEngine;

public class MapCell : MonoBehaviour
{
    public enum CellType
    {
        Sea = 1,
        Grassland = 2,
        River = 3,
        Mountain = 4,
        Desert = 5,
        Snowland = 6,
        SnowMountain = 7,
        Wasteland = 8,
    }

    // Properties
    public CellType MapCellType = CellType.Wasteland;
}
