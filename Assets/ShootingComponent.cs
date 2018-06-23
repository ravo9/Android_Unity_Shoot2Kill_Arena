using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingComponent : MonoBehaviour {

    private CharacterMovementComponent playerMovementComponent;

    public GameObject bulletPrefab;
    public Transform leftSideBulletSpawn;
    public Transform rightSideBulletSpawn;

    private int shootingFreezer;
    private int shootingFreezingValue;

    // Use this for initialization
    void Start () {

        playerMovementComponent = GameObject.Find("Simon").GetComponent<CharacterMovementComponent>();

        shootingFreezer = 0;
        shootingFreezingValue = 5;
    }
	
	
	void FixedUpdate () {

        if (shootingFreezer > 0)
            shootingFreezer--;
	}

    public void Shoot()
    {
        if (shootingFreezer <= 0)
        {
            if (playerMovementComponent.getDirection() == -1)
            {
                var bullet = (GameObject)Instantiate(bulletPrefab, leftSideBulletSpawn.position, leftSideBulletSpawn.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-1600.0f * Time.deltaTime, 0.0f);
                Destroy(bullet, 2.0f);
            }
            else if (playerMovementComponent.getDirection() == 1)
            {
                var bullet = (GameObject)Instantiate(bulletPrefab, rightSideBulletSpawn.position, rightSideBulletSpawn.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1600.0f * Time.deltaTime, 0.0f);
                Destroy(bullet, 2.0f);
            }

            shootingFreezer = 5;
        }
    }
}
