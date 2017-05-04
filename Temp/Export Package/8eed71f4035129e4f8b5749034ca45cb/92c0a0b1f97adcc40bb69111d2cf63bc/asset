using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //door & death vars
    private GameObject Door;
    public DeathScene grimReaper;
    private DoorStateMachineController controller;

    //end of door & death vars
    public float maxSpeed = 3;
	public float speed = 50f;
	public float jumpPower = 150f;

    //keys var
    private int keys;

    //Booleans
    public bool grounded;
    private bool frozen;

    //References
    private Rigidbody2D rb2d;
	private Animator anim;


	// Use this for initialization
	void Start () 
	{
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();

        //door & death variable instantiation
        Door = GameObject.FindGameObjectWithTag("Door");
        controller = Door.GetComponent<DoorStateMachineController>();
        keys = 0;
        frozen = false;
    }
	
	// Update is called once per frame
	void Update () 
	{
		anim.SetBool ("Grounded", grounded);
		anim.SetFloat ("Speed", Mathf.Abs(rb2d.velocity.x));

		if (Input.GetAxis ("Horizontal") < -0.1f) 
		{
			transform.localScale = new Vector3 (-10, 10, 1);
		}

		if (Input.GetAxis ("Horizontal") > 0.1f) 
		{
			transform.localScale = new Vector3 (10, 10, 1);
		}

		if (Input.GetButtonDown("Jump") && grounded) 
		{
			rb2d.AddForce (Vector2.up * jumpPower);
		}
	}

	void FixedUpdate()
	{
        //Death
        if (!frozen)
        {
            PlayerWalkKeyboard();
        }
        else
        {
            freezePlayer();
            grimReaper.reap();
        }
    }

    public void PlayerWalkKeyboard()
    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        float h = Input.GetAxis("Horizontal");

        //fake friction 
        if (grounded)
        {
            rb2d.velocity = easeVelocity;
        }

        //Moving player
        rb2d.AddForce(Vector2.right * speed * h);

        //Limits player speed
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
    }

    private void freezePlayer()
    {
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void Damage()
	{
		gameObject.GetComponent<Animation> ().Play ("RedFlash");
	}

	public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
	{
		float timer = 0;
		while (knockDur > timer) 
		{
			timer += Time.deltaTime;
			rb2d.AddForce (new Vector3 (knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));
		}
		yield return 0;
	}

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Trap")
        {
            frozen = true;
        }
        if (target.gameObject.tag == "MonsterChip")
        {
            frozen = true;
        }

        if (target.gameObject.tag == "Key")
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
}
