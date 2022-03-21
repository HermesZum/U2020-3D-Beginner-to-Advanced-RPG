using UnityEngine;

namespace U3Gear.Library.Engine.Locomotion
{
    /// <summary>
    /// Base class for control the player
    /// </summary>
    public abstract class BasePlayerController : MonoBehaviour
    {
        [SerializeField]
        private float speed = 3; // speed of the player

        [SerializeField]
        private float rotationSpeed = 9; // rotation speed of the player

        private Rigidbody _rigidbody; // rigidbody that is attached to the player
        
        private Vector3 _movement; // movement position of the player

        private Quaternion _rotation; // rotation of the player

        /// <summary>
        /// Start is called on the frame when a script is enabled
        /// just before any of the Update methods are called the first time.
        /// </summary>
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>(); // initiates the reference to the rigid body
        }
        
        /// <summary>
        /// Fixed update the player position and velocity
        /// </summary>
        private void FixedUpdate()
        {
            var horizontalInput = Input.GetAxis("Horizontal"); // horizontal position of the player
            var verticalInput = Input.GetAxis("Vertical"); // vertical position of the player
            _movement = new Vector3(horizontalInput, 0, verticalInput); // movement direction
            _movement.Normalize(); // normalize movement direction
            var direction = Vector3.RotateTowards(transform.forward, _movement, Time.fixedDeltaTime * rotationSpeed, 0); // locate player rotation direction
            _rotation = Quaternion.LookRotation(direction); // player rotation with the specified forward and upwards directions.
            _rigidbody.MovePosition(_rigidbody.position + _movement * speed * Time.fixedDeltaTime); // rigidbody movement position
            _rigidbody.MoveRotation(_rotation); // rigidbody rotation with the specified direction
        }
    }
}
