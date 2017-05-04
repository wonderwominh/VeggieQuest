using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour {

    private float alphaFadeValue;
    public Texture curtain;
    private bool fadingToDeath;
    private bool faded;

	// Use this for initialization
	void Start () {
        alphaFadeValue = 0;
        fadingToDeath = false;
	}

    private void OnGUI()
    {
        GUI.color = new Color(0, 0, 0, alphaFadeValue);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), curtain);
    }

    // Update is called once per frame
    void Update () {
        if (!faded)
        {
            if (fadingToDeath && alphaFadeValue < 1)
            {
                alphaFadeValue += Mathf.Clamp01(Time.deltaTime / 1);
            }
            else if (alphaFadeValue > 1)
            {
                alphaFadeValue = 1;
            }else if (alphaFadeValue == 1)
            {
                faded = true;
            }
        }else { 
            SceneManager.LoadScene("DeathScene", LoadSceneMode.Single);
        }
    }

    public void onClick(string btnPushed)
    {
        if (btnPushed == "retry")
        {
            SceneManager.LoadSceneAsync("scene1", LoadSceneMode.Single);
        }
        else if (btnPushed == "quit")
        {
            SceneManager.LoadSceneAsync("WelcomePage", LoadSceneMode.Single);
        }
        else
        {
            Debug.Log("Invalid button choice for death scene.");
        }
    }

    public void reap()
    {
        fadingToDeath = true;
    }
}
