using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Registration : MonoBehaviour {
    
    public InputField username;
    public InputField email;
    public InputField password;
    public InputField confpwd;
    public Text message;
    
    public string UserDbURL = "http://wonderwominh.com/register.php";
    
    public void Validate() {
        if(username.text == "" || email.text == "" || password.text == "" || confpwd.text == "") {
            message.text = "Please enter all the fields!";
        }
        else {
            if(password.text == confpwd.text) {
                WWWForm form = new WWWForm();
                form.AddField("username", username.text);
                form.AddField("email", email.text);
                form.AddField("password", password.text);
                
                WWW w = new WWW(UserDbURL,form);
                StartCoroutine(register(w));
                
            }
            else {
                message.text = "Your password does not match!";
            }
        }
    }
    
    IEnumerator register(WWW w) {
        yield return w;
        if(w.error == null) {
            message.text = w.text;
            SceneManager.LoadScene("Login");
        }
        else {
            message.text = "ERROR: " + w.error;
        }
    }
}
