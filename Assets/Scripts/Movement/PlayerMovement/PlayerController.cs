using UnityEngine;

public class PlayerController : IDirectionController
{
    private Joystick _joystick;

    public PlayerController(Joystick joystick)
    {
        if (_joystick != null)
        {
            Debug.LogError($"Inject error in playerController with {joystick.gameObject.name}");
            return;
        }

        _joystick = joystick;
    }

    public Vector2 GetDirection()
    {
        return _joystick.Direction;
    }
}
