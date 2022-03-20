using UnityEngine;

namespace U3Gear.Library.Engine.Locomotion
{
    /// <summary>
    /// Base class for control the player
    /// </summary>
    public abstract class BasePlayerController : MonoBehaviour
    {
        [SerializeField]
        private float speed; // speed of the player

        private Vector3 _movement; // movement position of the player
        
        /// <summary>
        /// Fixed update the player position and velocity
        /// </summary>
        private void FixedUpdate()
        {
            var horizontalInput = Input.GetAxis("Horizontal"); // horizontal position of the player
            var verticalInput = Input.GetAxis("Vertical"); // vertical position of the player
            _movement = new Vector3(horizontalInput, 0, verticalInput); // movement direction
            _movement.Normalize(); // normalize movement direction
            transform.Translate(_movement * speed * Time.fixedDeltaTime); // transform position
        }
    }
}
