using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2DSpecific))]
    public class Platformer2DUserControlSpecific : MonoBehaviour
    {

		public Platformer2DUserControlSpecific instance{get; private set;}

		private PlatformerCharacter2DSpecific m_Character;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2DSpecific>();
			instance = this;
        }

		private void Start(){
		
		}

        private void Update()
        {
            
		}
		
		
		private void FixedUpdate()
        {
            // Pass all parameters to the character control script.
			float h = CrossPlatformInputManager.GetAxis("Horizontal");
			m_Character.Move(h);
        }

    }
}
