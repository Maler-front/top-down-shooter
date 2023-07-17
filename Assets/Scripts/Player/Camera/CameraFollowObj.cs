using UnityEngine;

public class CameraFollowObj : MonoBehaviour
{
    [Header("Joystick")]
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _joystickImpactCoefficient = 1f;

    [Header("Other")]
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _minDistance = 0.01f;

    public bool Moving { get; private set; }

    private void Awake()
    {
        if (_target == null) Debug.LogError($"No target for camera movement");
    }

    void FixedUpdate()
    {
        Moving = Vector2.Distance(transform.position, _target.position) > _minDistance;

        if(Moving)
        {
            Vector2 position = Vector2.Lerp(transform.position, (Vector2)_target.position + _joystick.Direction * _joystickImpactCoefficient, _speed * Time.deltaTime);
            transform.position = new Vector3(position.x, position.y, transform.position.z);
        }
    }
}
