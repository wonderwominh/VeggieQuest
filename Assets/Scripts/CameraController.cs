using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject PlayerObject;
    private Vector3 cameraOffsetFromPlayer;
	// Use this for initialization
	void Start () {
        cameraOffsetFromPlayer = transform.position - PlayerObject.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = PlayerObject.transform.position + cameraOffsetFromPlayer;
	}
}
