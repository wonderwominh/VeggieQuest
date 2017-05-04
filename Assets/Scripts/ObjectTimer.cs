using System.Collections;
using UnityEngine;

public class ObjectTimer : MonoBehaviour {
	//public float sec = 3f;
	public GameObject gameObject;
 
    void Start (){
			//gameObject.SetActive(false);
            StartCoroutine(RemoveAfterSeconds(2, gameObject));
			
    }
    IEnumerator RemoveAfterSeconds (int seconds, GameObject obj){
        yield return new WaitForSeconds(2);
        obj.SetActive(false);
    }

	
    
}
