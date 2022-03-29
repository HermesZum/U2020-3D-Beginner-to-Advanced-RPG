using U3Gear.Library.Engine.Navigation;
using UnityEngine;

namespace U3Gear.Core.Engine.Navigation
{
    internal sealed class PlayerNavigation : BaseNavigationCtrl
    {
        private float Speed { get; set; } = 3; // speed of the player
        private CharacterController Controller { get; set; } // rigidbody that is attached to the player
        private static Camera MainCamera { get; set; } // reference to the Main Camera

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        protected override void Awake()
        {
            Controller = GetComponent<CharacterController>(); // initiates the reference to the rigid body
            MainCamera = Camera.main;  // initiates the reference to the Main Camera
        }
        
        /// <summary>
        /// Fixed update the player position and velocity
        /// </summary>
        protected override void FixedUpdate()
        {
            var horizontalInput = Input.GetAxis("Horizontal"); // horizontal input of the player
            var verticalInput = Input.GetAxis("Vertical"); // vertical input of the player
            var movement = Vector3.zero; // initial movement position
            movement.Set(horizontalInput, 0, verticalInput); // movement input
            var cameraRotation = MainCamera.transform.rotation; // reference to the main camera rotation
            var targetDirection = cameraRotation * movement; // reference to the target direction
            targetDirection.y = 0; // target direction in the Y axis must be 0
            targetDirection.Normalize(); // target direction must have a magnitude of 1
            var interval = Time.fixedDeltaTime; // interval of time
            Controller.Move(targetDirection * (Speed * interval)); // rigidbody movement position
            var rotation = Quaternion.Euler(0, cameraRotation.eulerAngles.y, 0); // camera rotation
            Controller.transform.rotation = rotation; // movement rotation
        }
    }
}
