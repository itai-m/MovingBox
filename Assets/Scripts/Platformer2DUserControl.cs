using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_shot;

        public float VerticalAxis;
        public float HorizontalAxis;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            VerticalAxis = CrossPlatformInputManager.GetAxis("Vertical");
            HorizontalAxis = CrossPlatformInputManager.GetAxis("Horizontal");
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, v > 0, v < 0, m_shot);
            m_shot = false;
        }

        public void Shot() {
            m_shot = true;
        }
    }
}
