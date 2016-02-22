using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpriteEffect : MonoBehaviour {


    
    Image imageReference;
    public Color colorEffect;
    public float colorTime;
    // Use this for initialization
	void Start () {
        imageReference= GetComponent<Image>();
        Debug.Log("image reference!");
	}
	




	// Update is called once per frame
	void Update ()
    {

        imageReference.color =  Color.Lerp(imageReference.color, colorEffect, Time.deltaTime * colorTime);

	}
}
