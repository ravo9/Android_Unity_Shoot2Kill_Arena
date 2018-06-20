using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementComponent : MonoBehaviour {

    private Rigidbody2D rb2d;
    private float maxVelocity;
    private Vector2 velocity;

    private SpriteRenderer spriteR;
    private Sprite[] sprites;

    // -1 means 'left'; '1' means 'right'
    private int direction;

    private Vector2 buttonLeftPosition;

    int acc;
    int spriteChangeFreezer;
    int spriteFreezingValue;

    // Use this for initialization
    void Start() {

        rb2d = GetComponent<Rigidbody2D>();
        maxVelocity = 10.0f;
        velocity = new Vector2(0.0f, 0.0f);

        spriteR = GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("simonSpritesheetAr15");
        direction = 1;

        acc = 0;
        spriteFreezingValue = 20;
        spriteChangeFreezer = spriteFreezingValue;
    }

    // Update is called once per frame
    void Update() {

    }

    public void moveLeft()
    {
        velocity = new Vector2(-4.5f, 0.0f);
        if (rb2d.velocity.x > -3.5f)
        {
            rb2d.AddForce(velocity, ForceMode2D.Impulse);
        }

        // Spritesheet
        direction = -1;

        if (spriteChangeFreezer == 0)
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

    public void moveRight()
    {
        velocity = new Vector2(4.5f, 0.0f);
        if (rb2d.velocity.x < 3.5f)
        {
            rb2d.AddForce(velocity, ForceMode2D.Impulse);
        }

        // Spritesheet
        direction = 1;

        if (spriteChangeFreezer == 0)
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

    public void stopMoving()
    {
        rb2d.velocity = new Vector2(0.0f, rb2d.velocity.y);

        // Spritesheet
        if (direction == 1)
            spriteR.sprite = sprites[0];
        else
            spriteR.sprite = sprites[4];
    }

    public void jump()
    {
        velocity = new Vector2(0.0f, 24.0f);
        rb2d.AddForce(velocity, ForceMode2D.Impulse);
    }
}
