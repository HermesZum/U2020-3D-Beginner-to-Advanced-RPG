using U3Gear.Library.Engine.Cameras;
using UnityEngine;

namespace U3Gear.Core.Engine.Cameras
{
    internal sealed class PlayerCamera : BaseCamerasCtrl
    {
        /// <summary>
        /// Position the camera relative two points
        /// </summary>
        private Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
        
        /// <summary>
        ///  Camera rotation direction relative to the player
        /// </summary>
        private Vector3 Angles
        {
            get => transform.eulerAngles;
            set => transform.eulerAngles = value;
        }

        /// <summary>
        ///     Awake is called when the script instance is being loaded.
        /// </summary>
        protected override void Awake()
        {
            if (Target == null)
                Target = GameObject.Find("Player");
        }

        /// <summary>
        ///     LateUpdate is called after all Update functions have been called.
        ///     This is useful to order script execution.
        ///     For example a follow camera should always be implemented in LateUpdate
        ///     because it tracks objects that might have moved inside Update.
        /// </summary>
        protected override void LateUpdate()
        {
            if(!Target) return; // if not have target then return
            
            var angles = Angles.y; // acquire current rotation angle y for the camera
            var targetAngles = TargetAngles.y; // acquire current target rotation angle y for the target
            // Same as Lerp but makes sure the values interpolate correctly when they wrap around 360 degrees.
            // The parameter t is clamped to the range [0, 1]. Variables a and b are assumed to be in degrees.
            angles = Mathf.LerpAngle(angles, targetAngles, 0.5f); // update current rotation angles for the camera relative to the target
            Position = new Vector3(TargetPosition.x, TargetPosition.y + 5f, TargetPosition.z); // update current position for the camera
            var rotation = Quaternion.Euler(0, angles, 0); // acquire current rotation around Y for the camera
            var rotatedPosition = rotation * Vector3.forward; // acquire the camera rotation to the forward vector
            Position -= rotatedPosition * 10; // update current position for the camera but with the camera behind it
            transform.LookAt(Target.transform); // camera towards the target 
        }
    }
}