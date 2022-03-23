using UnityEngine;

namespace U3Gear.Library.Engine.Cameras
{
    public abstract class BaseCamerasCtrl : MonoBehaviour
    {
        protected GameObject Target { get; set; } // The target object that will be used to control the camera
        protected Vector3 TargetPosition => Target.transform.position; // The position of the camera's target
        protected Vector3 TargetAngles => Target.transform.eulerAngles; // The rotation angles of the camera's target'
        
        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        protected virtual void Awake()
        {

        }

        /// <summary>
        /// LateUpdate is called after all Update functions have been called.
        /// This is useful to order script execution.
        /// For example a follow camera should always be implemented in LateUpdate
        /// because it tracks objects that might have moved inside Update.
        /// </summary>
        protected virtual void LateUpdate()
        {

        }
    }
}
