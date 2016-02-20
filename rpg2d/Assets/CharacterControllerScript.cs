using UnityEngine;
using System.Collections;
using Interactions;

public class CharacterControllerScript : MonoBehaviour {


    public InputController inputController;
    public MovementController movementController;
    public InteractionController interactionController;

    public static CharacterControllerScript instance;
    public bool characterBusy;
    
    // Use this for initialization
	void Start () {

        instance = this;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
