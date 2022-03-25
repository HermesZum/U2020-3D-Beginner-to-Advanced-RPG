using UnityEngine;

namespace U3Gear.Library.Engine.Cameras
{
    public abstract class BaseCamerasCtrl : MonoBehaviour
    {
        /// <summary>
        ///     Awake is called when the script instance is being loaded.
        /// </summary>
        protected virtual void Awake()
        {
        }

        /// <summary>
        ///     Update is called every frame, if the MonoBehaviour is enabled.
        ///     Update is the most commonly used function to implement any kind of game behavior.
        /// </summary>
        protected virtual void Update()
        {
        }

        /// <summary>
        ///     LateUpdate is called after all Update functions have been called.
        ///     This is useful to order script execution.
        ///     For example a follow camera should always be implemented in LateUpdate
        ///     because it tracks objects that might have moved inside Update.
        /// </summary>
        protected virtual void LateUpdate()
        {
        }
    }
}