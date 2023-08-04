using UnityEngine;

public static class AngleCalculator
{
    public static float CalculateTargetAngleFromDirection(Vector2 direction)
    {
        float targetAngle = Mathf.Atan(direction.y / direction.x) * Mathf.Rad2Deg - 90f;
        return direction.x > 0 ? targetAngle : 180 + targetAngle;
    }

    public static Vector2 CalculateDirectionFromAngle(float angle)
    {
        float y = Mathf.Sin(angle * Mathf.Deg2Rad);
        float x = Mathf.Cos(angle * Mathf.Deg2Rad);
        return new Vector2(x, y);
    }

    /*public static float CalculateDirection(float currentAngle, float targetAngle)
    {
        return Mathf.Abs(targetAngle - currentAngle) > Mathf.Abs(360f - (targetAngle - currentAngle)) ? 1 : -1;
    }

    public static float CalculateLookAngle(float currentAngle, Vector2 direction)
    {
        float targetAngle = CalculateTargetAngle(direction);
        return Mathf.Abs(targetAngle - currentAngle) > Mathf.Abs(360f - (targetAngle - currentAngle)) ? 1 : -1;
    }*/
}
