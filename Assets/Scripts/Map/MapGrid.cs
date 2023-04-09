using UnityEngine;

public class MapGrid
{
    // Grid
    private readonly GameObject[,] _grid;

    // Properties
    private readonly int _width;
    private readonly int _height;
    private readonly float _cell_width;
    private readonly float _cell_height;
    private readonly Vector3 _origin_position;

    /// <summary>
    /// Create a grid of the specified size
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="origin_position"></param>
    /// <param name="cell_size"></param>
    public MapGrid(int width, int height, Vector3 origin_position, Vector3 cell_size)
    {
        _width = width;
        _height = height;
        _cell_width = cell_size.x;
        _cell_height = cell_size.y;
        _origin_position = origin_position;

        _grid = new GameObject[_width, _height];
    }

    /// <summary>
    /// Convert the specified position to the x and y coordinate on the grid
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x * _cell_width, y * _cell_height, 0) + _origin_position;
    }

    /// <summary>
    /// Convert the specified position to the x and y coordinates
    /// </summary>
    /// <param name="position"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void GetXY(Vector3 position, out int x, out int y)
    {
        x = Mathf.FloorToInt((position - _origin_position).x / _cell_width);
        y = Mathf.FloorToInt((position - _origin_position).y / _cell_height);
    }

    /// <summary>
    /// Return the game object for map cell at the specified coordinates
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public GameObject GetMapCell(int x, int y)
    {
        return _grid[x, y];
    }

    /// <summary>
    /// Return the game object for map cell at the specified position
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public GameObject GetMapCell(Vector3 position)
    {
        GetXY(position, out int x, out int y);

        return _grid[x, y];
    }
}
