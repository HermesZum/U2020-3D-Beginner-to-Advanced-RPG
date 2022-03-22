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
        private Vector3 Movement { get; set; } // movement position of the player
        private Quaternion Rotation { get; set; } // rotation of the player
        
        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        protected virtual void Awake()
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
            Movement = new Vector3(horizontalInput, 0, verticalInput); // movement direction
            Movement.Normalize(); // normalize movement direction
            var interval = Time.fixedDeltaTime;
            var direction = Vector3.RotateTowards(transform.forward, Movement, interval * RotationSpeed, 0); // locate player rotation direction
            Rotation = Quaternion.LookRotation(direction); // player rotation with the specified forward and upwards directions.
            RigidBody.MovePosition(RigidBody.position + Movement * Speed * interval); // rigidbody movement position
            RigidBody.MoveRotation(Rotation); // rigidbody rotation with the specified direction
        }
    }
}
