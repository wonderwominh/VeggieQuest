using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchManager :  MonoBehaviour {
	
	public static bool guiTouch = false;

	public void TouchInput (GUITexture texture)
	{
		if(texture.HitTest(Input.GetTouch(0).position))
		{
			switch (Input.GetTouch(0).phase)
			{
			case TouchPhase.Began:
				SendMessage("OnFirstTouchBegan");
				SendMessage("OnFirstTouch");
				guiTouch = true;
				break;
			case TouchPhase.Stationary:
				SendMessage("OnFirstTouchStayed");
				SendMessage("OnFirstTouch");
				guiTouch = true;
				break;
			case TouchPhase.Moved:
				SendMessage("OnFirstTouchMoved");
				SendMessage("OnFirstTouch");
				guiTouch = true;
				break;
			case TouchPhase.Ended:
				SendMessage("OnFirstTouchEnded");
				guiTouch = false;
				break;
			}
		}
		if(texture.HitTest(Input.GetTouch(1).position))
		{
			switch (Input.GetTouch(1).phase)
			{
			case TouchPhase.Began:
				SendMessage("OnFirstTouchBegan");
				SendMessage("OnFirstTouch");
				break;
			case TouchPhase.Stationary:
				SendMessage("OnFirstTouchStayed");
				SendMessage("OnFirstTouch");
				break;
			case TouchPhase.Moved:
				SendMessage("OnFirstTouchMoved");
				SendMessage("OnFirstTouch");
				break;
			case TouchPhase.Ended:
				SendMessage("OnFirstTouchEnded");
				break;
			}
		}
	}

}
