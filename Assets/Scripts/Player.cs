using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

    //door & death vars
    private GameObject Door;
    public DeathScene grimReaper;
    private DoorStateMachineController controller;
    //end of door & death vars

    private float maxSpeed = 200f;
	private float jumpPower = 1000f;
    private float moveForce = 200f,  maxVelocity = 32f;

    //Booleans
    public bool grounded;
    private bool frozen;
	public bool wallSliding;
	public bool facingRight = true;
	public bool canJump;

    //References
    private Rigidbody2D rb2d;
	private Animator anim;
	public Transform wallCheckPoint;
	public bool wallCheck;
	public LayerMask wallLayerMask;

    //Exposed variables for on-screen button support
    private bool spacebar;
    private float h;

    // Use this for initialization
    void Start () 
	{
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();

        //door & death variable instantiation
        Door = GameObject.FindGameObjectWithTag("Door");
        controller = Door.GetComponent<DoorStateMachineController>();
        frozen = false;

		//jump bool instantiation
		canJump = true;
    }

	void FixedUpdate()
	{
        //Death
        if (!frozen)
        {
            PlayerWalk();
        }
        else
        {
            freezePlayer();
            grimReaper.reap();
        }

    }

    public void PlayerWalk(string moveButton = "", bool jumpButton = false)
    {
        //ease velocity constants
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;
        //end of ease velocity constants

        float forceX = 0f;
        float forceY = 0f;
        float vel = Mathf.Abs(rb2d.velocity.x);

        //support for buttons on-screen
        if (!(moveButton.Length > 0))
        {
            h = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            switch (moveButton)
            {
                case "left":
                    h = -1.0F;
                    break;
                case "right":
                    h = 1.0F;
                    break;
                default:
                    Debug.Log("[ERROR] Invalid button send to PLayer::PlayerWalk() function.");
                    h = 0;
                    break;
            }
        }

        if (!jumpButton)
        {
            spacebar = Input.GetKey(KeyCode.Space);
        }
        else
        {
            spacebar = true;
        }
        //end of support for buttons onscreen

        //fake friction 
        rb2d.velocity = easeVelocity;
        if (grounded)
        {
            rb2d.AddForce((Vector2.right * moveForce) * h);
        }
        else
        {
            rb2d.AddForce((Vector2.right * moveForce / 2) * h);
        }
        //end of fake friction

        // handle moving left + right
        if (h > 0)
        {
            if (vel < maxVelocity)
            {
                forceX = moveForce;
            }
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        else if (h < 0)
        {

            if (vel < maxVelocity)
            {
                forceX = -moveForce;
            }
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * -1f;
            transform.localScale = scale;
        }
        //end of handle moving left + right

        //jumping
        if (spacebar)
        {
            if (grounded)
            {
                grounded = false;

                if (h < 0)
                {
                    transform.localScale = new Vector3(-10, 10, 1);
                    facingRight = false;
                }

                if (h > 0)
                {
                    transform.localScale = new Vector3(10, 10, 1);
                    facingRight = true;
                }

                if (spacebar && !wallSliding && canJump)
                {
                    forceY = jumpPower;
                    canJump = false;
                }
            }
        }
        //end of jumping

        // wall sliding
        if (!grounded)
        {
            wallCheck = Physics2D.OverlapCircle(wallCheckPoint.position, 0.1f, wallLayerMask);
            if (wallCheck)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, -0.5f);

                wallSliding = true;
                if (spacebar)
                {
                    if (facingRight)
                    {
                        rb2d.AddForce(new Vector2(-1, 1) * jumpPower);
                    }
                    else
                    {
                        rb2d.AddForce(new Vector2(1, 1) * jumpPower);
                    }
                }
            }
        }

        if (wallCheck == false || grounded)
        {
            wallSliding = false;
            canJump = true;
        }
        //end of wall sliding

        //moving player & updating animation control variables
        rb2d.AddForce(new Vector2(forceX, forceY));
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        //end move player

        //Limits player speed horizontally
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
        //end of player speed limit horizontal
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
		rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
		while (knockDur > timer) 
		{
			timer += Time.deltaTime;
			rb2d.AddForce (new Vector3 (knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));
		}
		yield return 0;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        int layerNumber = collision.gameObject.layer;
        if(layerNumber == 8)
        {
            // then we are grouded...
            grounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Trap")
        {
            frozen = true;
        }
        if (target.gameObject.tag == "MonsterChip")
        {
            if (target.GetType() == typeof(BoxCollider2D))
            {
                // hit monster head
                Destroy(target.gameObject);
            }
            else
            {
                // hit monster body
                frozen = true;
            }
        }

        if (target.gameObject.tag == "KillFloor") 
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
