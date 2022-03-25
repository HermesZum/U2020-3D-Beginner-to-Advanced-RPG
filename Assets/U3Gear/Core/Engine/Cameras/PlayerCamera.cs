using Cinemachine;
using U3Gear.Library.Engine.Cameras;
using UnityEngine;

namespace U3Gear.Core.Engine.Cameras
{
    internal sealed class PlayerCamera : BaseCamerasCtrl
    {
        private static GameObject CmFreeLookCamera { get; set; } // reference to free look camera GameObject
        private CinemachineFreeLook FreeLookCamera { get; set; } // reference to Cinemachine free look camera


        /// <summary>
        ///     Awake is called when the script instance is being loaded.
        /// </summary>
        protected override void Awake()
        {
            CmFreeLookCamera = GameObject.Find("/Cameras/CM FreeLookCamera"); // return to cache the CM FreeLookCamera GameObject
            FreeLookCamera = CmFreeLookCamera.GetComponent<CinemachineFreeLook>(); // return to cache the CinemachineFreeLook component
        }
        
        /// <summary>
        ///     Update is called every frame, if the MonoBehaviour is enabled.
        ///     Update is the most commonly used function to implement any kind of game behavior.
        /// </summary>
        protected override void Update()
        {
            if (Input.GetMouseButtonDown(1)) // if press and hold the right mouse button
            {
                FreeLookCamera.m_XAxis.m_MaxSpeed = 400; // set the camera max speed in the X axis
                FreeLookCamera.m_YAxis.m_MaxSpeed = 10; // set the camera max speed in the Y axis
            }
            else if (Input.GetMouseButtonUp(1)) // if releases the right mouse button
            {
                FreeLookCamera.m_XAxis.m_MaxSpeed = 0; // set the camera max speed in the X axis
                FreeLookCamera.m_YAxis.m_MaxSpeed = 0; // set the camera max speed in the Y axis               
            }
        }       

        /// <summary>
        ///     LateUpdate is called after all Update functions have been called.
        ///     This is useful to order script execution.
        ///     For example a follow camera should always be implemented in LateUpdate
        ///     because it tracks objects that might have moved inside Update.
        /// </summary>
        protected override void LateUpdate()
        {
        }
    }
}