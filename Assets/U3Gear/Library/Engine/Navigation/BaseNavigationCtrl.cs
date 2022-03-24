using UnityEngine;

namespace U3Gear.Library.Engine.Navigation
{
    /// <summary>
    /// Base class for control the player
    /// </summary>
    public abstract class BaseNavigationCtrl : MonoBehaviour
    {
        private float Speed { get; set; } = 3; // speed of the player
        private float RotationSpeed { get; set; } = 9; // rotation speed of the player
        private Rigidbody RigidBody { get; set; } // rigidbody that is attached to the player

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        protected virtual void Start()
        {
            RigidBody = GetComponent<Rigidbody>(); // initiates the reference to the rigid body
        }
        
        /// <summary>
        /// Fixed update the player position and velocity
        /// </summary>
        protected virtual void FixedUpdate()
        {
            var horizontalInput = Input.GetAxis("Horizontal"); // horizontal position of the player
            var verticalInput = Input.GetAxis("Vertical"); // vertical position of the player
            var movement = Vector3.zero;
            movement.Set(horizontalInput, 0, verticalInput); // movement input
            movement.Normalize(); // update and normalize the player position
            var interval = Time.fixedDeltaTime; // interval of time
            var direction = Vector3.RotateTowards(transform.forward, movement, RotationSpeed * interval, 0); // direction of movement
            var rotation = Quaternion.LookRotation(direction);
            RigidBody.MovePosition(RigidBody.position + movement * (Speed * interval)); // rigidbody movement position
            RigidBody.MoveRotation(rotation);
        }
    }
}
