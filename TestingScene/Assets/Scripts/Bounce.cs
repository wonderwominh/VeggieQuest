using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {

	public float force = 500f;

	private Animator anim;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>(); 
		
	}

	void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == "Player")
		{
			target.gameObject.GetComponent<playerMove>().BouncePlayer(force);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
