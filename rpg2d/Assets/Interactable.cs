using UnityEngine;
using System.Collections;

namespace Interactions
{
    public class Interactable : MonoBehaviour
   {

        // Use this for initialization
        void Start()
        {

        }
        virtual public void OnInteract()
        {
            Debug.Log("Virtual base class Called!");
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}