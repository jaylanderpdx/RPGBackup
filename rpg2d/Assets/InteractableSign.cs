using UnityEngine;
using System.Collections;

namespace Interactions
{

    public class InteractableSign : Interactable
    {

       public string signText;
        bool playerInteracted = false;
        // Use this for initialization
        void Start()
        {

        }

        public override void OnInteract()
        {
            playerInteracted = !playerInteracted;

            if (playerInteracted)
                DialogBox.Show(signText);
            else
                DialogBox.Hide();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}