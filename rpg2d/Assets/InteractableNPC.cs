using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace Interactions
{

    public class InteractableNPC : Interactable
    {

    // Use this for initialization


    bool playerInteracted = false;
    public string textNPC;

      public override void OnInteract()
      {
            playerInteracted = !playerInteracted;

            if (playerInteracted)
            {
                DialogBox.Show(textNPC);

            }
            else
                DialogBox.Hide();

        }
    

   
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
}