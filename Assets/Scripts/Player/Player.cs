using UnityEngine;
using UnitsMovement;

public class Player : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 5f;
    [SerializeField] private Rigidbody2D _movementRigidbody;
    [SerializeField] private Transform _rotatingObject;

    [SerializeField] private Joystick _movementJoystick;
    [SerializeField] private Joystick _lookingJoystick;

    private Movement _movement;
    private Rotator _looking;

    private void Awake()
    {
        if (_movementJoystick == null) Debug.LogError($"На скрипте Player у объекта {gameObject.name} нет movementJoystick");
        if (_lookingJoystick == null) Debug.LogError($"На скрипте Player у объекта {gameObject.name} нет lookingJoystick");

        var movementController = new PlayerController(_movementJoystick);
        var movementRotationController = new PlayerController(_movementJoystick);
        var lookingController = new PlayerController(_lookingJoystick);

        if (_movementRigidbody == null) Debug.LogError($"На скрипте Player у объекта {gameObject.name} нет movementRigidbody");
        if (_rotatingObject == null) Debug.LogError($"На скрипте Player у объекта {gameObject.name} нет rotatingObject");

        _movement = new Movement(movementController, _movementRigidbody, _playerSpeed, movementRotationController);
        _looking = new Rotator(lookingController, _rotatingObject);
    }

    private void FixedUpdate()
    {
        _movement.MovementUpdate();
        _looking.RotateUpdate();
    }
}
