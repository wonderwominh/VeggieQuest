using UnityEngine;

public class playerMove : MonoBehaviour {
    public GameObject Door;
    public DeathScene grimReaper;
    public DoorStateMachineController controller;
    public float moveForce = 20f, jumpForce = 700f, maxVelocity = 4f;

	private Rigidbody2D myBody;
	private Animator anim;
	private bool grounded;
    private bool frozen;
 
	void Awake(){
		variableInit();
    }
    
	// Use this for initialization
	void Start () {
        Door = GameObject.FindGameObjectWithTag("Door");
        controller = Door.GetComponent<DoorStateMachineController>();
        frozen = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!frozen)
        {
            PlayerWalk();
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

	public void PlayerWalk(string moveButton = "", bool jumpButton = false) {
		float forceX = 0f;
		float forceY = 0f;
		float vel = Mathf.Abs(myBody.velocity.x);
        bool spacebar;
        float h;

        if (!(moveButton.Length > 0))
        {
		    h = Input.GetAxisRaw("Horizontal");
        }else
        {
            switch (moveButton)
            {
                case "left":
                    Debug.Log("Detected Left");
                    h = -1.0F;
                    break;
                case "right":
                    Debug.Log("Detected Right");
                    h = 1.0F;
                    break;
                default:
                    Debug.Log("[ERROR] Invalid button send to playerMove::PlayerWalk() function.");
                    h = 0;
                    break;
            }
        }

        if (!jumpButton) { 
            spacebar = Input.GetKey(KeyCode.Space);
        }else
        {
            Debug.Log("Detected Jump");
            spacebar = true;
        }

        if (h > 0)
		{
			if (vel < maxVelocity)
			{
				forceX = moveForce;
			}

			Vector3 scale = transform.localScale;
			scale.x = 1f;
			transform.localScale = scale;

			//anim.SetBool("walkAnimation", true);


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

			//anim.SetBool("walkAnimation", true);
		}
		else if (h == 0) {

			//anim.SetBool("walkAnimation", false);
		}

		if (spacebar){
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
