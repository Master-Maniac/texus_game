using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class AccelerometerInput : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Input.acceleration.x, Input.acceleration.y, 0);
    }
}
public class Player : MonoBehaviour {

		private Animator anim;
		private CharacterController controller;
        
		public float speed = 600.0f;
		public float turnSpeed = 400.0f;
		private Vector3 moveDirection = Vector3.zero;
		public float gravity = 20.0f;

		void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
		}
    private void FixedUpdate()
    {
        if (controller.transform.position.z > 111)
        {
            SceneManager.LoadScene("DemoScene");
        }
    }
    void SetTransformZ(float n)
    {   
        transform.position = Vector3.MoveTowards (transform.position, new Vector3(n, transform.position.y, transform.position.z ),4f);
    }
    
    void Update(){


             anim.SetInteger("AnimationPar", 1);
			//if(controller.isGrounded)
            moveDirection = transform.forward *4f*Time.time;//* Input.GetAxis("Vertical") * speed;
			
        controller.Move(moveDirection * Time.deltaTime);
        if ( Input.GetKeyDown(KeyCode.D))
            SetTransformZ(transform.position.x+5f);
        if (Input.GetKeyDown(KeyCode.A))
            SetTransformZ(transform.position.x - 5f);
			moveDirection.y -= gravity * Time.deltaTime;
		}
}
