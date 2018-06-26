using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttributesComponent : MonoBehaviour {

    // Types: 'Simon', 'Enemy'
    public string characterType;

    private CharacterMovementComponent playerMovementComponent;

    private string currentGunType;

	// Use this for initialization
	void Start () {

        playerMovementComponent = GameObject.Find("Simon").GetComponent<CharacterMovementComponent>();

        if (characterType == "Simon")
            currentGunType = "Colts";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setGun(string newGun)
    {
        currentGunType = newGun;

        Debug.Log("CHECK 01");

        if (currentGunType == "Colts")
            playerMovementComponent.setSprites("Colts");
        else if (currentGunType == "Ar15")
            playerMovementComponent.setSprites("Ar15");
    }
}
