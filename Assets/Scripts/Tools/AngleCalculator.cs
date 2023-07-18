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
        float tan = Mathf.Tan((angle + 90) * Mathf.Deg2Rad);
        Vector2 direction = new Vector2(1f, tan);
        Debug.Log($"{angle}, {tan}, {direction.normalized}");
        return direction.normalized;
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
