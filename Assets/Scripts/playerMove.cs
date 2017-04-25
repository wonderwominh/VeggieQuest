using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour {
    public GameObject Door;
    public DeathScene grimReaper;
    public DoorStateMachineController controller;
    public float moveForce = 20f, jumpForce = 700f, maxVelocity = 4f;

	private Rigidbody2D myBody;
	private Animator anim;
	private bool grounded;
    private bool frozen;
    private int keys;
 
	void Awake(){
		variableInit();
    }
    
	// Use this for initialization
	void Start () {
        Door = GameObject.FindGameObjectWithTag("Door");
        controller = Door.GetComponent<DoorStateMachineController>();
        //Physics2D.IgnoreLayerCollision(0, 10);
        keys = 0;
        frozen = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!frozen)
        {
            PlayerWalkKeyboard();
        }else
        {
            freezePlayer();
            grimReaper.reap();
        }
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
		if (target.gameObject.tag == "Trap")
		{
            frozen = true;
		}
		if (target.gameObject.tag == "MonsterChip")
		{
            frozen = true;
		}

		if (target.gameObject.tag == "Key" )
		{	
			Destroy(target.gameObject);
            controller.keyCount = 1;
		}

        if (target.gameObject.tag == "Door")
        {
            controller.openDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.gameObject.tag == "Door")
        {
            controller.closeDoor();
        }
    }

    private void freezePlayer()
    {
        myBody.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
