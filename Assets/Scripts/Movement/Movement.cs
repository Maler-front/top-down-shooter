using UnityEngine;

namespace UnitsMovement
{
    public class Movement : Rotator
    {
        private IDirectionController _movementController;
        private Rigidbody2D _rigidbody;
        private float _moveSpeed = 5f;

        public Movement(IDirectionController movementController, Rigidbody2D rigidbody, float moveSpeed, IDirectionController controller) : base(controller, rigidbody.transform)
        {
            if (_movementController != null || _rigidbody != null)
            {
                Debug.LogError($"Inject error in Movement class");
                return;
            }

            _movementController = movementController;
            _rigidbody = rigidbody;
            _moveSpeed = moveSpeed;
        }

        public void MovementUpdate()
        {
            if (_movementController.GetDirection() == Vector2.zero)
                return;

            var angle = RotateUpdate();
            if (angle > 20f)
                return;

            _rigidbody.MovePosition(_rigidbody.position + _movementController.GetDirection() * Time.fixedDeltaTime * _moveSpeed);
        }
    }
}

