using UnityEngine;

namespace U3Gear.Library.Engine.Cameras
{
    public abstract class BaseCamerasCtrl : MonoBehaviour
    {
        protected GameObject Target { get; set; } // The target object that will be used to control the camera
        protected Vector3 TargetPosition => Target.transform.position; // The position of the camera's target
        protected Vector3 Offset { get; set; } // The offset of the camera

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        protected virtual void Awake()
        {

        }

        /// <summary>
        /// Start is called on the frame when a script is enabled
        /// just before any of the Update methods is called the first time.
        /// Like the Awake function, Start is called exactly once in the lifetime of the script but after
        /// </summary>
        protected virtual void Start()
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
