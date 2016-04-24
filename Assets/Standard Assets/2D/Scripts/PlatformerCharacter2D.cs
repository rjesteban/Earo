using System;
using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets._2D;
namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {

		public static PlatformerCharacter2D instance{get; private set;}

        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] public LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character
		[SerializeField] public LayerMask m_WhatIsStairs;					//A mask determining what is staircase to the character

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;            // Whether or not the player is grounded.
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        public Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.

		private Transform m_StairCheck;    // A position marking where to check if the player is staired.
		const float k_StairedRadius = .2f; // Radius of the overlap circle to determine if grounded

		private bool m_Staired = false;  // For determining which way the player is currently facing.

		private bool etherealMode = false;

		//private GameObject _light;

        private void Awake()
        {
			// Setting up references.
			//_light = GameObject.Find("Point light");
			m_StairCheck = transform.Find ("StairCheck");
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("HeadCheck");
            
			m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();

			instance = this;
        }


        private void FixedUpdate()
        {
            m_Grounded = false;
            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    m_Grounded = true;
            }

			m_Staired = Physics2D.OverlapCircle (m_StairCheck.position, k_StairedRadius, m_WhatIsStairs);

			m_Anim.SetBool ("Staired", m_Staired);

            m_Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
			m_Anim.SetFloat("climbSpeed", m_Rigidbody2D.velocity.y);
        }


        public void Move(float move, float movey, bool crouch, bool jump)
        {
            // If crouching, check to see if the character can stand up
            if (!crouch && m_Anim.GetBool("Crouch"))
            {
                // If the character has a ceiling preventing them from standing up, keep them crouching
                if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
                {
                    crouch = true;
                }
            }

            // Set whether or not the character is crouching in the animator
            m_Anim.SetBool("Crouch", crouch);
			//m_Anim.SetBool (

            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {
                // Reduce the speed if crouching by the crouchSpeed multiplier
                move = (crouch ? move*m_CrouchSpeed : move);

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                m_Anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                    // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }
            // If the player should jump...
            if (m_Grounded && jump && m_Anim.GetBool("Ground"))
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Anim.SetBool("Ground", false);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            }

			if(m_Staired){
				m_Anim.SetBool("Staired", m_Staired);
				m_Anim.SetFloat("climbSpeed", Mathf.Abs (movey));
				m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, (movey*m_MaxSpeed)/3);

				if(movey == 0){
					m_Rigidbody2D.velocity = new Vector2(0, 0);
					m_Rigidbody2D.gravityScale = 0.0f;
				} else
					m_Rigidbody2D.gravityScale = 1.0f;
			}
			else{
				m_Rigidbody2D.gravityScale = 1.0f;
			}
			if (etherealMode) {
				m_Rigidbody2D.velocity = new Vector2 (move * m_MaxSpeed / 2, (movey * m_MaxSpeed) / 2);
				GetComponent<SpriteRenderer>().color = new Color32(0,244,255,255);
			}

        }

		public void launchEtherealMode(){
			etherealMode = true;
			StartCoroutine(disableEtherealModeAfter(5.0f));
		}

		IEnumerator disableEtherealModeAfter(float seconds){
			yield return new WaitForSeconds (seconds);
			etherealMode = false;
			GetComponent<SpriteRenderer>().color = new Color32(255,255,255,255);
		}


        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

//			Quaternion theRotation = _light.transform.localRotation;
//			theRotation.y *= -1;
//			_light.transform.localRotation = theRotation;
        }
    }
}
