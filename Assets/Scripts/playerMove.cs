using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour {
	
	public float moveForce = 20f, jumpForce = 700f, maxVelocity = 4f;
	//public GameObject WoodSprite;

	private Rigidbody2D myBody;
	private Animator anim;
	private bool grounded;


	void Awake(){
		variableInit();
	}
	
	

	// Use this for initialization
	void Start () {
		


	}
	
	// Update is called once per frame
	void FixedUpdate () {
		PlayerWalkKeyboard();
	}
	
	void variableInit(){
		
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void PlayerWalkKeyboard() {
		float forceX = 0f;
		float forceY = 0f;
		float vel = Mathf.Abs(myBody.velocity.x);
		float h = Input.GetAxisRaw("Horizontal");

		if (h > 0)
		{
			if (vel < maxVelocity)
			{
				forceX = moveForce;
			}

			Vector3 scale = transform.localScale;
			scale.x = 1f;
			transform.localScale = scale;

			anim.SetBool("walkAnimation", true);


		}
		else if (h < 0)
		{

			if (vel < maxVelocity)
			{
				forceX = -moveForce;
			}

			Vector3 scale = transform.localScale;
			scale.x = -1f;
			transform.localScale = scale;

			anim.SetBool("walkAnimation", true);
		}
		else if (h == 0) {

			anim.SetBool("walkAnimation", false);
		}

		if (Input.GetKey(KeyCode.Space)){
			if (grounded){
				grounded = false;
				forceY = jumpForce;
			}
		}
		myBody.AddForce(new Vector2(forceX, forceY));

	
	}

	public void BouncePlayer(float force){
		myBody.AddForce(new Vector2(force/3, force));
	}

	void OnCollisionEnter2D (Collision2D target){
		if (target.gameObject.tag == "Ground"){
			grounded = true;
		}
	}

	void OnTriggerEnter2D(Collider2D target){




		if (target.tag == "Trap")
			{
				//Destroy(target.gameObject);
				Destroy(gameObject);


				//WoodSprite.SetActive(true);


			}
		if (target.tag == "MonsterChip")
		{
			//Destroy(target.gameObject);
			Destroy(gameObject);


			//WoodSprite.SetActive(true);


		}

		if (target.tag == "Key" )
		{	
			Destroy(target.gameObject);
			//Destroy(gameObject);

		}
		
	}
}
