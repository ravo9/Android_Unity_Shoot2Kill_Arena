using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameElementComponent : MonoBehaviour {

    public string gameElementType;

    private GameObject simon;
    private CharacterAttributesComponent playerAttributesComponent;
    private float distanceFromCharacter;

    private float x1, x2, y1, y2;
    private float reactionDistance;

	// Use this for initialization
	void Start () {

        simon = GameObject.Find("Simon");
        playerAttributesComponent = GameObject.Find("Simon").GetComponent<CharacterAttributesComponent>();

        // CHANGE FOR RELATIVE VALUE;
        reactionDistance = 200;
    }
	
	// Update is called once per frame
	void Update () {

        x1 = transform.position.x;
        y1 = transform.position.y;

        x2 = simon.transform.position.x;
        y2 = simon.transform.position.y;

        distanceFromCharacter = ((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        
        
        if (distanceFromCharacter < reactionDistance)
            playerAttributesComponent.setGun("Ar15");
    }
}
