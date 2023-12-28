using UnityEngine;
using System.Collections;

namespace AstronautPlayer
{
	public class AstronautPlayer : MonoBehaviour {
		private Animator anim;
		private CharacterController controller;

		public float speed = 600.0f;
		public float turnSpeed = 400.0f;
        public float jumpForce = 10;
        private Vector3 moveDirection = Vector3.zero;
		public float gravity = 20.0f;

		void Start () {
			controller = GetComponent<CharacterController>();
			anim =  GetComponent<Animator>();
		}

		void Update () {
			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) {
				anim.SetInteger("AnimationPar", 1);
			} else {
				anim.SetInteger("AnimationPar", 0);
			}

			if (controller.isGrounded) {
				moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;

                if (Input.GetButton("Jump"))
                {
                    anim.SetTrigger("jump");
                    moveDirection.y = jumpForce;
                }
            }

            controller.Move(moveDirection * Time.deltaTime);

            float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			
			moveDirection.y -= gravity * Time.deltaTime;
		}
	}
}
