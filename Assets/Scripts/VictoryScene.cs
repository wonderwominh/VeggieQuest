using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScene : MonoBehaviour
{
    public Texture curtain;
    public string levelToLoad;
    public string victorySceneToLoad;

    private float alphaFadeValue;
    private bool fadingOut;
    private bool faded;

    // Use this for initialization
    void Start ()
    {
        alphaFadeValue = 0;
        fadingOut = false;
    }

    private void OnGUI()
    {
        GUI.color = new Color(0, 0, 0, alphaFadeValue);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), curtain);
    }

    // Update is called once per frame
    void Update ()
    {
        if (!faded)
        {
            if (fadingOut && alphaFadeValue < 1)
            {
                alphaFadeValue += Mathf.Clamp01(Time.deltaTime / 1);
            }
            else if (alphaFadeValue > 1)
            {
                alphaFadeValue = 1;
            }
            else if (alphaFadeValue == 1)
            {
                faded = true;
            }
        }
        else
        {
            SceneManager.LoadScene(victorySceneToLoad, LoadSceneMode.Single);
        }
    }

    public void onClick(string btnPushed)
    {
        if (btnPushed == "nextLevel")
        {
            SceneManager.LoadSceneAsync(levelToLoad, LoadSceneMode.Single);
        }
        else if (btnPushed == "quit")
        {
            SceneManager.LoadSceneAsync("WelcomePage", LoadSceneMode.Single);
        }
        else
        {
            Debug.Log("Invalid button choice for victory scene.");
        }
    }

    public void fadeOut()
    {
        fadingOut = true;
    }

    public bool isFaded()
    {
        return faded;
    }
}
