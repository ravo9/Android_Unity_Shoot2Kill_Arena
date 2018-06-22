using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementComponent : MonoBehaviour {

    private Rigidbody2D rb2d;
    private float maxVelocity;
    private Vector2 velocityLeft, velocityRight, velocityJump;

    private SpriteRenderer spriteR;
    private Sprite[] sprites;

    // -2 means 'going left'; -1 means 'staying towards left'; '1' means 'staying towards right'; '2' means 'going right' 
    private int state;

    private Vector2 buttonLeftPosition;

    int acc;
    int spriteChangeFreezer;
    int spriteFreezingValue;

    // Use this for initialization
    void Start() {

        rb2d = GetComponent<Rigidbody2D>();
        maxVelocity = 10.0f;

        velocityRight = new Vector2(4.5f, 0.0f);
        velocityLeft = new Vector2(-4.5f, 0.0f);
        velocityJump = new Vector2(0.0f, 24.0f);

        spriteR = GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("simonSpritesheetAr15");
        state = 1;

        acc = 0;
        spriteFreezingValue = 2;
        spriteChangeFreezer = spriteFreezingValue;
    }

    // Update is called once per frame
    void Update() {
        SpriteUpdate();
    }

    public void MoveLeft()
    {
        state = -2;
        
        if (rb2d.velocity.x > -3.5f)
            rb2d.AddForce(velocityLeft * Time.deltaTime * 100, ForceMode2D.Impulse);
    }

    public void MoveRight()
    {
        state = 2;

        if (rb2d.velocity.x < 3.5f)
            rb2d.AddForce(velocityRight * Time.deltaTime * 100, ForceMode2D.Impulse);
    }

    public void StopMoving()
    {
        rb2d.velocity = new Vector2(0.0f, rb2d.velocity.y);

        // Spritesheet
        if (state == -2)
            state = -1;
        else if (state == 2)
            state = 1;
    }

    public void SpriteUpdate()
    {
        
        if (state == -1)
            spriteR.sprite = sprites[4];
        else if (state == 1)
            spriteR.sprite = sprites[0];
        else if (state == -2)
        {
            if (spriteChangeFreezer <= 0)
            {
                if (acc % 3 == 0)
                    spriteR.sprite = sprites[5];
                else if (acc % 3 == 1)
                    spriteR.sprite = sprites[6];
                else
                    spriteR.sprite = sprites[7];

                spriteChangeFreezer = spriteFreezingValue;
                acc++;
            }

            spriteChangeFreezer--;
        }
        else if (state == 2)
        {
            if (spriteChangeFreezer <= 0)
            {
                if (acc % 3 == 0)
                    spriteR.sprite = sprites[1];
                else if (acc % 3 == 1)
                    spriteR.sprite = sprites[2];
                else
                    spriteR.sprite = sprites[3];

                spriteChangeFreezer = spriteFreezingValue;
                acc++;
            }

            spriteChangeFreezer--;
        }
    }

   
    public void Jump()
    {
        rb2d.AddForce(velocityJump, ForceMode2D.Impulse);
    }
}
