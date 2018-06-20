using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiControlComponent : MonoBehaviour
{
    private PlayerMovementComponent playerMovementComponent;

    private Vector2 movementButtonLeftPosition;
    private Vector2 movementButtonRightPosition;

    void Start ()
    {
        playerMovementComponent = GetComponent<PlayerMovementComponent>();

        movementButtonLeftPosition = GameObject.Find("movementButtonLeft").transform.position;
        movementButtonRightPosition = GameObject.Find("movementButtonRight").transform.position;
    }
	
	
	void FixedUpdate ()
    {

        if (Input.GetKey(KeyCode.A))
        {
            if (!Input.GetKey(KeyCode.D))
                playerMovementComponent.moveLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (!Input.GetKey(KeyCode.A))
                playerMovementComponent.moveRight();
        }
        else
            playerMovementComponent.stopMoving();


        if (Input.GetKeyDown(KeyCode.Space))
            playerMovementComponent.jump();
        
    
        if (Input.touchCount > 0)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;

            if (touchPosition.x > movementButtonLeftPosition.x - 200 && touchPosition.x < movementButtonLeftPosition.x + 200)
                if (touchPosition.y > movementButtonLeftPosition.y - 200 && touchPosition.y < movementButtonLeftPosition.y + 200)
                    playerMovementComponent.moveLeft();

            if (touchPosition.x > movementButtonRightPosition.x - 200 + 1000 && touchPosition.x < movementButtonRightPosition.x + 200 + 1000)
                if (touchPosition.y > movementButtonRightPosition.y - 200 && touchPosition.y < movementButtonRightPosition.y + 200)
                    playerMovementComponent.moveRight();
        }
    }
}
