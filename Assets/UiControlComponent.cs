using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiControlComponent : MonoBehaviour
{
    private CharacterMovementComponent playerMovementComponent;
    private ShootingComponent shootingComponent;

    private int screenWidth;
    private float originalRoundButtonWidth;
    private float roundButtonWidth;
    private float jumpButtonWidth;
    private float jumpButtonHeight;

    private Vector2 controlElementsScale;

    private Vector2 movementButtonLeftPosition;
    private Vector2 movementButtonRightPosition;
    private Vector2 movementButtonJumpPosition;
    private Vector2 shootButtonPosition;

    void Start ()
    {
        screenWidth = Screen.width;
        playerMovementComponent = GameObject.Find("Simon").GetComponent<CharacterMovementComponent>();
        shootingComponent = GameObject.Find("Simon").GetComponent<ShootingComponent>();
        originalRoundButtonWidth = GameObject.Find("buttonMoveLeft").GetComponent<RectTransform>().rect.width;

        // Scalling
        //controlElementsScale = new Vector3(4.0f, 4.0f, 0);
        controlElementsScale = new Vector3(screenWidth * 0.1f / originalRoundButtonWidth * 1.0f, screenWidth * 0.1f / originalRoundButtonWidth * 1.0f, 0.0f);

        GameObject.Find("buttonMoveLeft").transform.localScale = controlElementsScale;
        GameObject.Find("buttonMoveRight").transform.localScale = controlElementsScale;
        GameObject.Find("buttonMoveJump").transform.localScale = controlElementsScale;
        GameObject.Find("buttonShoot").transform.localScale = controlElementsScale;

        roundButtonWidth = GameObject.Find("buttonMoveLeft").GetComponent<RectTransform>().rect.width * controlElementsScale.x;
        jumpButtonWidth = GameObject.Find("buttonMoveJump").GetComponent<RectTransform>().rect.width * controlElementsScale.x;
        jumpButtonHeight = GameObject.Find("buttonMoveJump").GetComponent<RectTransform>().rect.height * controlElementsScale.x;

        // Position setting
        movementButtonLeftPosition = new Vector2(screenWidth * 0.1f, screenWidth * 0.1f);
        movementButtonRightPosition = new Vector2(screenWidth * 0.9f, screenWidth * 0.1f);
        movementButtonJumpPosition = new Vector2(screenWidth * 0.5f, screenWidth * 0.1f);
        shootButtonPosition = new Vector2(screenWidth * 0.8f, screenWidth * 0.1f);

        GameObject.Find("buttonMoveLeft").transform.position = movementButtonLeftPosition;
        GameObject.Find("buttonMoveRight").transform.position = movementButtonRightPosition;
        GameObject.Find("buttonMoveJump").transform.position = movementButtonJumpPosition;
        GameObject.Find("buttonShoot").transform.position = shootButtonPosition;
    }
	
    void Update() {}
	
	void FixedUpdate ()
    {

        if (Input.GetKey(KeyCode.A))
        {
            if (!Input.GetKey(KeyCode.D))
                playerMovementComponent.MoveLeft();  
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

        if (Input.GetKeyDown(KeyCode.LeftControl))
            shootingComponent.Shoot();


        if (Input.touchCount > 0)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;

            if (touchPosition.x > movementButtonLeftPosition.x - roundButtonWidth * 0.5f && touchPosition.x < movementButtonLeftPosition.x + roundButtonWidth * 0.5f)
                if (touchPosition.y > movementButtonLeftPosition.y - roundButtonWidth * 0.5f && touchPosition.y < movementButtonLeftPosition.y + roundButtonWidth * 0.5f)
                    playerMovementComponent.MoveLeft();

            if (touchPosition.x > movementButtonRightPosition.x - roundButtonWidth * 0.5f && touchPosition.x < movementButtonRightPosition.x + roundButtonWidth * 0.5f)
                if (touchPosition.y > movementButtonRightPosition.y - roundButtonWidth * 0.5f && touchPosition.y < movementButtonRightPosition.y + roundButtonWidth * 0.5f)
                    playerMovementComponent.MoveRight();

            if (touchPosition.x > movementButtonJumpPosition.x - jumpButtonWidth * 0.5f && touchPosition.x < movementButtonJumpPosition.x + jumpButtonWidth * 0.5f)
                if (touchPosition.y > movementButtonJumpPosition.y - jumpButtonHeight * 0.5f && touchPosition.y < movementButtonJumpPosition.y + jumpButtonHeight * 0.5f)
                    playerMovementComponent.Jump();

            if (touchPosition.x > shootButtonPosition.x - roundButtonWidth * 0.5f && touchPosition.x < shootButtonPosition.x + roundButtonWidth * 0.5f)
                if (touchPosition.y > shootButtonPosition.y - roundButtonWidth * 0.5f && touchPosition.y < shootButtonPosition.y + roundButtonWidth * 0.5f)
                    shootingComponent.Shoot();
        }
    }
}
