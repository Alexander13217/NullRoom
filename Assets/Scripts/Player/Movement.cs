using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        public Vector3 Velocity { get; private set; }

        private CharacterController _char;

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
            Velocity = direction * _speed;

            _char.Move(Velocity * Time.deltaTime);
        }
    }
}
