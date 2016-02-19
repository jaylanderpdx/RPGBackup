using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetGems : MonoBehaviour {

    Text GemCount;
    // Use this for initialization
	void Start () {
        GemCount = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

        GemCount.text = "x " + CurrencyScript.Instance.gems.ToString();
	}
}
