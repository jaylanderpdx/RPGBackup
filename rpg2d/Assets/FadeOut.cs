using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOut : MonoBehaviour {


    public float fadeTime = 1.0f;
    private float fadeTimer = 0f;
    public float moveSpeed = 1f;
    private Text text;
	// Use this for initialization
	void Start ()
    {
        text = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.Translate(new Vector3(0f,moveSpeed * Time.deltaTime, 0f));
        fadeTimer += Time.deltaTime;
        text.color = Color.Lerp(text.color, Color.clear, Time.deltaTime);
        if ( fadeTimer >= fadeTime)
        {
            Destroy(gameObject);
        }
	}
}
