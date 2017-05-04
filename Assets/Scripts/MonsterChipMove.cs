using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChipMove : MonoBehaviour {
	[SerializeField]
	private Transform startPos, endPos;

	private bool collision;
	private bool monsterCol;

	public float speed = 1f;
	private Rigidbody2D myBody;

	void Awake(){
		myBody = GetComponent<Rigidbody2D>(); 
		Physics2D.IgnoreLayerCollision(4, 9);
	}


	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		Move();
		ChangeDirection();
		
	}

	void Move (){
		myBody.velocity = new Vector2 (transform.localScale.x, 0) * speed;
		
	}

	void ChangeDirection (){
		collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("GroundMove"));

		if (!collision){
			Vector3 temp = transform.localScale;
			if (temp.x < 0){
				temp.x  = Mathf.Abs(temp.x);
			}else {
				temp.x *= -1f;
			}

			transform.localScale = temp;
		}
	}

}
