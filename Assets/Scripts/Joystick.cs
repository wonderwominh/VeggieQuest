using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

	private playerMove player;

	void Awake(){
		player = GameObject.Find ("Player").GetComponent<playerMove> ();

	}


	public void OnPointerDown (PointerEventData data){
		if (gameObject.name == "left") {
			player.setMoveLeft (true);
		} else {
			player.setMoveLeft (false);
		}


	} 

	public void OnPointerUp (PointerEventData data){
		player.DoNotMove ();
	} 


}
