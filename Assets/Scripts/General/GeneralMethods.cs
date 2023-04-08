using UnityEngine;

public static class GeneralMethods
{
    /// <summary>
    /// Convert the specified direction to an angle
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    public static float ConvertDirectionToAngle(Vector3 direction)
    {
        // Calculate the radians
        float angle = Mathf.Atan2(direction.y, direction.x);
        
        // Convert the randians to angle
        angle*= Mathf.Rad2Deg;

        // Fix the angle
        if (angle < 0)
        {
            angle += 360;
        }

        return angle;
    }

    /// <summary>
    /// Return the color for RGB (0-255)
    /// </summary>
    /// <param name="r"></param>
    /// <param name="g"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Color GetColor(float r, float g, float b)
    {
        return new Color(r / 255, g / 255, b / 255);
    }
}
