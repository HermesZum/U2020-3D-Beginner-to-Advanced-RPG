using UnityEngine;

namespace U3Gear.Library.Engine.Navigation
{
    /// <summary>
    /// Base class for control the player
    /// </summary>
    public abstract class BaseNavigationCtrl : MonoBehaviour
    {
        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        protected virtual void Awake()
        {
        }
        
        /// <summary>
        /// Fixed update the player position and velocity
        /// </summary>
        protected virtual void FixedUpdate()
        {
        }
    }
}
