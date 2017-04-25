using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuCtrl : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

	public void OnPointerDown(PointerEventData data){
		if (gameObject.name == "B_Login") {
			SceneManager.LoadScene(Login);
			
		}	

		if (gameObject.name == "B_Register") {
			SceneManager.LoadScene(Registration);

		}
		
	}	

//	public void LoadScene(string sceneName) {
//		SceneManager.LoadScene(sceneName);
//
//	}

}