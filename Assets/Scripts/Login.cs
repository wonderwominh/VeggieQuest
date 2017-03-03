using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Login : MonoBehaviour {
    
    public InputField username;
    public InputField password;
    public Text message;
    
    string LoginURL = "http://wonderwominh.com/Login.php";
    
	public void VerifyLogin() {
        WWWForm form = new WWWForm();
        form.AddField("username", username.text);
        form.AddField("password", password.text);
        
        WWW w = new WWW(LoginURL,form);
        StartCoroutine(verify(w));
    }
    
    IEnumerator verify(WWW w) {
        yield return w;
        if(w.error == null) {
            message.text = w.text;
        }
        else {
            message.text = "ERROR: " + w.error;
        }
    }

}
