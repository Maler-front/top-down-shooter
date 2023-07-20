using UnityEngine;

public class Rotator 
{
    private IDirectionController _rotatorController;
    private Transform _rotatingObject;
    private float _rotationSpeed = 180f;

    public Rotator(IDirectionController controller, Transform rotatingObject)
    {
        if (_rotatorController != null || _rotatingObject != null)
        {
            Debug.LogError($"Inject error in Movement class");
            return;
        }

        _rotatorController = controller;
        _rotatingObject = rotatingObject;
    }

    public float RotateUpdate()
    {
        Vector2 direction = _rotatorController.GetDirection();
        if (direction == Vector2.zero)
            return 0f;

        Quaternion currentRotation = _rotatingObject.transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, AngleCalculator.CalculateTargetAngleFromDirection(direction));
        _rotatingObject.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, _rotationSpeed * Time.fixedDeltaTime);
        return Quaternion.Angle(_rotatingObject.rotation, targetRotation);
    }
}
