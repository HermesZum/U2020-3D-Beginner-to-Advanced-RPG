using UnityEngine;

namespace U3Gear.Library.Engine.Navigation
{
    /// <summary>
    /// Base class for control the player
    /// </summary>
    public abstract class BaseNavigationCtrl : MonoBehaviour
    {
        private float Speed { get; set; } = 3; // speed of the player
        private Rigidbody RigidBody { get; set; } // rigidbody that is attached to the player
        private Camera CameraMain  { get; set; } // main camera 

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        protected virtual void Awake()
        {
            RigidBody = GetComponent<Rigidbody>(); // initiates the reference to the rigid body
            CameraMain = Camera.main;
        }
        
        /// <summary>
        /// Fixed update the player position and velocity
        /// </summary>
        protected virtual void FixedUpdate()
        {
            var inputDirection = Vector3.zero; // initial input direction of the player movement
            inputDirection.x = Input.GetAxis("Horizontal"); // input direction in the X axis (Horizontal)
            inputDirection.z = Input.GetAxis("Vertical"); // input direction in the Z axis (Vertical)
            if(inputDirection == Vector3.zero) return; // if not using input, then return
            var cameraDirection = CameraMain.transform.rotation * inputDirection; // position camera direction in relation to main camera rotation multiplied by movement input
            var targetDirection = new Vector3(cameraDirection.x, 0, cameraDirection.z); // position of target direction in relation to the camera direction
            // if player is moving in forward direction
            if (inputDirection.z >= 0)
            {
                // change player rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), 0.1f);
            }
            var interval = Time.fixedDeltaTime; // interval of time
            RigidBody.MovePosition(RigidBody.position + targetDirection.normalized * (Speed * interval)); // rigidbody movement position
        }
    }
}
