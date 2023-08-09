using UnityEngine;

namespace AstronautPlayer
{

    public class AstronautPlayer : MonoBehaviour {

		private Animator anim;
		private CharacterController controller;

		public float speed = 10.0f;
		public float turnSpeed = 150.0f;
        public float jumpForce = 15f;
		public float gravity = 30.0f;
        private Vector3 moveDirection = Vector3.zero;

		void Start () {
			controller = GetComponent<CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
		}

		void Update (){
			if (controller.isGrounded){
				moveDirection = transform.forward * Input.GetAxisRaw("Vertical") * speed;

                if (moveDirection == Vector3.zero)
				{
                    anim.SetInteger("AnimationPar", 0);
                }
				else
				{
                    anim.SetInteger("AnimationPar", 1);
                }
			}
			else
			{
                anim.SetInteger("AnimationPar", 0);
            }

            if (controller.isGrounded && Input.GetButton("Jump"))
            {
				print("Jump");
                moveDirection.y = jumpForce;
            }

            float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			controller.Move(moveDirection * Time.deltaTime);
			moveDirection.y -= gravity * Time.deltaTime;
		}
	}
}
