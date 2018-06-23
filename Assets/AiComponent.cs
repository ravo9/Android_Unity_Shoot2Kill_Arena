using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiComponent : MonoBehaviour
{

    private CharacterMovementComponent enemyMovementComponent;

    private float changeDirectionFreezer;
    private float changeDirectionFreezingValue;

    private int direction;
    

    void Start()
    {

        enemyMovementComponent = GetComponent<CharacterMovementComponent>();

        changeDirectionFreezingValue = 4000.0f * Time.deltaTime;
        changeDirectionFreezer = changeDirectionFreezer;

        direction = 1;
    }


    void FixedUpdate()
    {

        if (changeDirectionFreezer > 0)
            changeDirectionFreezer--;
        else
        {
            ChangeDirection();
            changeDirectionFreezer = changeDirectionFreezingValue;
        }
            

        if (direction == 1)
            enemyMovementComponent.MoveRight();
        else if (direction == -1)
            enemyMovementComponent.MoveLeft();
    }


    void ChangeDirection()
    {
        direction *= -1;
    }

}
