using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        public static bool m_Jump;
		private bool m_Crouch;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
			m_Crouch = false;
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
			if (CrossPlatformInputManager.GetButtonDown ("Crouch")){
				m_Crouch = !m_Crouch;
			}
		}
		
		
		private void FixedUpdate()
        {
            // Read the inputs.

            float h = CrossPlatformInputManager.GetAxis("Horizontal");
			float v = CrossPlatformInputManager.GetAxis ("Vertical");
            // Pass all parameters to the character control script.
            m_Character.Move(h, v, m_Crouch, m_Jump);
			//m_Character.MoveVertically (v); 
            m_Jump = false;
        }
    }
}
