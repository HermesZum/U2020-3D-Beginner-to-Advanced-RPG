using UnityEngine;

namespace U3Gear.Library.Engine.Locomotion
{
    /// <summary>
    /// Base class for control the player
    /// </summary>
    public abstract class BasePlayerController : MonoBehaviour
    {
        [SerializeField]
        private float speed; // speed of the player

        private Vector3 _movement; // movement position of the player
        
        private Rigidbody _rigidbody; // rigid body that is attached to the player

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
            _rigidbody.MovePosition(_rigidbody.position + _movement * speed * Time.fixedDeltaTime); // rigidbody movement position
        }
    }
}
