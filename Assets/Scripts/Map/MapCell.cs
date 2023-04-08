using UnityEngine;

public class MapCell : MonoBehaviour
{
    public enum CellType
    {
        Ground = 1,
        Water = 2,
        Desert = 4,
        Mountain = 8,
        Snow = 16,
    }

    /// <summary>
    /// Set up the map properties
    /// </summary>
    /// <param name="cell_type"></param>
    public void SetupCell(CellType cell_type)
    {
        GameObject sprite_object = this.transform.Find("Sprite").gameObject;
        SpriteRenderer sprite_renderer = sprite_object.GetComponent<SpriteRenderer>();

        if (cell_type == CellType.Ground)
        {
            sprite_renderer.color = GeneralMethods.GetColor(48, 185, 83);
        }
        else if (cell_type == CellType.Water)
        {
            sprite_renderer.color = GeneralMethods.GetColor(48, 130, 185);
        }
        else if (cell_type == CellType.Desert)
        {
            sprite_renderer.color = GeneralMethods.GetColor(185, 160, 48);
        }
        else if (cell_type == CellType.Mountain)
        {
            sprite_renderer.color = GeneralMethods.GetColor(181, 106, 35);
        }
    }
}
