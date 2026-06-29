using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        public bool IsMoving => _velocity.sqrMagnitude > 0;

        private CharacterController _char;
        private Vector3 _velocity;

        private void Awake()
        {
            _char = GetComponent<CharacterController>();
        }

        private void Update()
        {
            Move(ReadInput());
        }

        private Vector3 ReadInput()
        {
            Vector3 vertical = transform.forward * Input.GetAxisRaw("Vertical");
            Vector3 horizontal = transform.right * Input.GetAxisRaw("Horizontal");

            return (vertical + horizontal).normalized;
        }

        private void Move(Vector3 direction)
        {
            _velocity = direction * _speed;

            _char.Move(_velocity * Time.deltaTime);
        }
    }
}
