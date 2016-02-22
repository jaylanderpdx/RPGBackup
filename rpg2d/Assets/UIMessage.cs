using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMessage : MonoBehaviour {


    public static UIMessage instance;
    Text textToDisplay;
    // Use this for initialization
	void Start () {
        instance = this;
        textToDisplay = GetComponent<Text>();
	
	}	

    static public void ShowMessage(string message, Color messagecolor, float duration)
    {

        instance.Show(message, messagecolor, duration); 

    }

    void Show(string message, Color messagecolor, float duration)
    {
        textToDisplay.enabled = true;
        textToDisplay.color = messagecolor;
        textToDisplay.text = message;

    }

    // Update is called once per frame
    void Update () {
	
	}
}
