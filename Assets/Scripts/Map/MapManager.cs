using UnityEngine;

public class MapManager : MonoBehaviour
{
    private void Start()
    {
        CreateMap1();
    }

    /// <summary>
    /// Read
    /// </summary>
    private void CreateMap1()
    {
        // Get the data for map1
        TextAsset map_data_text = MapData.Creator.Map1;

        // Create the map based on the data
        MapGrid.CreateMap(map_data_text);
    }
}
