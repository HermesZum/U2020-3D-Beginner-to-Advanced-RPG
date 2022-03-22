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
        ///     Awake is called when the script instance is being loaded.
        /// </summary>
        protected override void Awake()
        {
            if (Target == null)
                Target = GameObject.Find("Player");
        }

        /// <summary>
        ///     Start is called on the frame when a script is enabled
        ///     just before any of the Update methods is called the first time.
        ///     Like the Awake function, Start is called exactly once in the lifetime of the script but after
        /// </summary>
        protected override void Start()
        {
            Offset = Position - TargetPosition; // initial offset position of the camera
        }

        /// <summary>
        ///     LateUpdate is called after all Update functions have been called.
        ///     This is useful to order script execution.
        ///     For example a follow camera should always be implemented in LateUpdate
        ///     because it tracks objects that might have moved inside Update.
        /// </summary>
        protected override void LateUpdate()
        {
            var position = TargetPosition + Offset; // acquire the camera position
            Position = position; // update the camera position
        }
    }
}