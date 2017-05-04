using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour {

	public static bool guiTouch = false;

	public void TouchInput(GUITexture texture)
	{
        if(Input.touchCount > 0 && Input.touchCount <= 1) {
            if (texture.HitTest(Input.GetTouch(0).position))
            {
                switch (Input.GetTouch(0).phase)
                {
                    case TouchPhase.Began:
                        SendMessage("OnFirstTouchBegan");
                        guiTouch = true;
                        break;
                    case TouchPhase.Stationary:
                        SendMessage("OnFirstTouchStayed");
                        guiTouch = true;
                        break;
                    case TouchPhase.Ended:
                        SendMessage("OnFirstTouchStop");
                        guiTouch = false;
                        break;
                }
            }
        }else if(Input.touchCount>1){
            if (texture.HitTest(Input.GetTouch(0).position))
            {
                switch (Input.GetTouch(0).phase)
                {
                    case TouchPhase.Began:
                        SendMessage("OnFirstTouchBegan");
                        guiTouch = true;
                        break;
                    case TouchPhase.Stationary:
                        SendMessage("OnFirstTouchStayed");
                        guiTouch = true;
                        break;
                    case TouchPhase.Ended:
                        SendMessage("OnFirstTouchStop");
                        guiTouch = false;
                        break;
                }
            }
            if (texture.HitTest(Input.GetTouch(1).position))
		    {
			    switch(Input.GetTouch(1).phase)
			    {
			    case TouchPhase.Began:
				    SendMessage("OnSecondTouchBegan");
                        guiTouch = true;
                        break;
			    case TouchPhase.Stationary:
				    SendMessage("OnSecondTouchStayed");
                        guiTouch = true;
                        break;
			    case TouchPhase.Ended:
				    SendMessage("OnSecondTouchStop");
                        guiTouch = false;
                        break;
			    }
             }
        }
    }
}
