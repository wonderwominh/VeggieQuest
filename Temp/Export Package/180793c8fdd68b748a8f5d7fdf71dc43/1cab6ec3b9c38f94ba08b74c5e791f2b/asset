using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour {

	public static bool guiTouch = false;

	public void TouchInput(GUITexture texture)
	{
		if(texture.HitTest(Input.GetTouch(0).position))
		{
			switch(Input.GetTouch(0).phase)
			{
			case TouchPhase.Began:
				SendMessage ("OnFirstTouchBegan");
				guiTouch = true;
				break;
			case TouchPhase.Stationary:
				SendMessage("OnFirstTouchStayed");
				guiTouch = true;
				break;
			case TouchPhase.Moved:
				SendMessage("OnFirstTouchMoved");
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
			switch(Input.GetTouch(1).phase)
			{
			case TouchPhase.Began:
				SendMessage("OnSecondTouchBegan");
				break;
			case TouchPhase.Stationary:
				SendMessage("OnSecondTouchStayed");
				break;
			case TouchPhase.Moved:
				SendMessage("OnSecondTouchMoved");
				break;
			case TouchPhase.Ended:
				SendMessage("OnSecondTouchEnded");
				break;
			}
		}
	}
}
