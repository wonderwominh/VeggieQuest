using UnityEngine;

public class ButtonMovement : TouchManager {
	public enum type {LeftButton, RightButton, JumpButton};
	public type buttonType;

    private type firstButtonType;
    private type secondButtonType;

	private float maxSpeed = 3;
	private float moveSpeed = 50f;
	private float jumpHeight = 150f;

	public GameObject playerObject = null;
    private Player playerMovement = null;
	public GUITexture buttonTexture = null;

    private string previousMove = "";
	void Start () {
        playerMovement = playerObject.GetComponent<Player>();
	}

	void Update() {
		TouchInput (buttonTexture);
	}

    void sendMessage(type buttonType)
    {
        switch (buttonType)
        {
            case type.LeftButton:
                playerMovement.PlayerWalk(moveButton: "left", jumpButton: false);
                previousMove = "left";
            break;
            case type.RightButton:
                playerMovement.PlayerWalk(moveButton: "right", jumpButton: false);
                previousMove = "right";
            break;
            case type.JumpButton:
                if(previousMove.Length < 0)
                {
                    playerMovement.PlayerWalk(moveButton: previousMove, jumpButton: true);
                }else
                {
                    playerMovement.PlayerWalk(moveButton: "", jumpButton: true);
                }
            break;
        }
    }

    void OnFirstTouchStop()
    {
        previousMove = "";
    }

    void OnSecondTouchStop()
    {
        previousMove = "";
    }

    void OnFirstTouchBegan ()
	{
        firstButtonType = buttonType;
        sendMessage(firstButtonType);
	}
    void OnSecondTouchBegan ()
    {
        secondButtonType = buttonType;
        sendMessage(secondButtonType);
    }

    void OnFirstTouchStayed()
    {
        sendMessage(firstButtonType);
    }

    void OnSecondTouchStayed()
    {
        sendMessage(secondButtonType);
    }
    void OnFirstTouch ()
	{
        //can just call other function since it's the same thing
        OnFirstTouchBegan();
    }

	void OnSecondTouch ()
	{
        //can just call other function since it's the same thing
        OnSecondTouchBegan();
    }

}