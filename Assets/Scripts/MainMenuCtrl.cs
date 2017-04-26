using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void onClickLoadLevel(string level)
    {
        SceneManager.LoadSceneAsync(level, LoadSceneMode.Single);
    }
}
