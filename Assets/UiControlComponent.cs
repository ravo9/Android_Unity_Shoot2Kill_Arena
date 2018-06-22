using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiControlComponent : MonoBehaviour
{
    private PlayerMovementComponent playerMovementComponent;

    private int screenWidth;
    private float roundButtonWidth;

    private Vector2 controlElementsScale;

    private Vector2 movementButtonLeftPosition;
    private Vector2 movementButtonRightPosition;
    private Vector2 movementButtonJumpPosition;

    void Start ()
    {
        playerMovementComponent = GameObject.Find("Simon").GetComponent<PlayerMovementComponent>();

        screenWidth = Screen.width;

        roundButtonWidth = GameObject.Find("buttonMoveLeft").GetComponent<RectTransform>().rect.width;

        movementButtonLeftPosition = new Vector2(screenWidth * 0.1f, screenWidth * 0.1f);
        movementButtonRightPosition = new Vector2(screenWidth * 0.8f, screenWidth * 0.1f);
        movementButtonJumpPosition = new Vector2(screenWidth * 0.45f, screenWidth * 0.1f);

        //controlElementsScale = new Vector3(4.0f, 4.0f, 0);

        controlElementsScale = new Vector3(screenWidth * 0.1f/roundButtonWidth * 1.0f, screenWidth * 0.1f/roundButtonWidth * 1.0f, 0.0f);

        GameObject.Find("buttonMoveLeft").transform.localScale = controlElementsScale;
        GameObject.Find("buttonMoveRight").transform.localScale = controlElementsScale;
        GameObject.Find("buttonMoveJump").transform.localScale = controlElementsScale;

        GameObject.Find("buttonMoveLeft").transform.position = movementButtonLeftPosition;
        GameObject.Find("buttonMoveRight").transform.position = movementButtonRightPosition;
        GameObject.Find("buttonMoveJump").transform.position = movementButtonJumpPosition;
    }
	
    void Update() {}
	
	void FixedUpdate ()
    {

        if (Input.GetKey(KeyCode.A))
        {
            if (!Input.GetKey(KeyCode.D))
            {
                playerMovementComponent.MoveLeft();
            }   
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (!Input.GetKey(KeyCode.A))
                playerMovementComponent.MoveRight();
        }
        else
            playerMovementComponent.StopMoving();


        if (Input.GetKeyDown(KeyCode.Space))
            playerMovementComponent.Jump();
        
    
        if (Input.touchCount > 0)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;

            if (touchPosition.x > movementButtonLeftPosition.x - 100 && touchPosition.x < movementButtonLeftPosition.x + 100)
                if (touchPosition.y > movementButtonLeftPosition.y - 100 && touchPosition.y < movementButtonLeftPosition.y + 100)
                    playerMovementComponent.MoveLeft();

            if (touchPosition.x > movementButtonRightPosition.x - 100 && touchPosition.x < movementButtonRightPosition.x + 100)
                if (touchPosition.y > movementButtonRightPosition.y - 100 && touchPosition.y < movementButtonRightPosition.y + 100)
                    playerMovementComponent.MoveRight();

            if (touchPosition.x > movementButtonJumpPosition.x - 100 && touchPosition.x < movementButtonJumpPosition.x + 100)
                if (touchPosition.y > movementButtonJumpPosition.y - 100 && touchPosition.y < movementButtonJumpPosition.y + 100)
                    playerMovementComponent.Jump();
        }
    }
}
