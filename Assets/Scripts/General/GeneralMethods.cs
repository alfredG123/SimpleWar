using UnityEngine;

public static class GeneralMethods
{
    /// <summary>
    /// Convert direction to angle
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    public static float ConvertDirectionToAngle(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle < 0)
        {
            angle += 360;
        }

        return angle;
    }
}
