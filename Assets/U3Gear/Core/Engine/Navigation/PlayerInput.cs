using U3Gear.Library.Engine.Navigation;
using UnityEngine;

namespace U3Gear.Core.Engine.Navigation
{
    public class PlayerInput : BaseInputCtrl
    {
        private static float Horizontal => Input.GetAxis("Horizontal");
        private static float Vertical => Input.GetAxis("Vertical");
        public static Vector2 Movement => new Vector2(Horizontal, Vertical);
    }
}
