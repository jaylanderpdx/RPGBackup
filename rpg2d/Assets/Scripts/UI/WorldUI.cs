using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WorldUI : MonoBehaviour {


    public GameObject floatingTextNormal;
    public GameObject floatingTextCritical;

    public static WorldUI instance;

	// Use this for initialization
	void Start () {
     
        instance = this;
	
	}


    public void DamageNormalAt(Vector3 position, int amount)
    {

        TextAtLocation(amount.ToString(), position);
    }
    public void DamageCriticalAt(Vector3 position, int amount)
    {

        TextAtLocationCritical(amount.ToString(), position);
    }


    public void TextAtLocation(string text, Vector3 position)
    {

        GameObject obj = GameObject.Instantiate(floatingTextNormal, position, Quaternion.identity) as GameObject;
        Text Textobj = obj.GetComponentInChildren<Text>();

        if(Textobj)
        {
            Textobj.text = text;
        }
    }
    public void TextAtLocationCritical(string text, Vector3 position)
    {

        GameObject obj = GameObject.Instantiate(floatingTextCritical, position, Quaternion.identity) as GameObject;

        obj.transform.SetParent(GetComponent<WorldUI>().transform.parent,false);
        
        Text Textobj = obj.GetComponentInChildren<Text>();
        
        if (Textobj)
        {
            Textobj.text = text;
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
