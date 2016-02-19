using UnityEngine;
using System.Collections;

public class CurrencyScript : MonoBehaviour {


    public static CurrencyScript Instance;
    public int gems;
    AudioSource GemSound;
    
    public enum CurrencyTypes
    {
        Gem,
        Gold,
        Silver
    }
   
       // Use this for initialization
	void Start () {
        GemSound = GetComponent<AudioSource>();
        Instance = this;
	
	}
	
    public void PickupCoin(CurrencyTypes pType, int count)
    {

        switch (pType)
        {
            case CurrencyTypes.Gem:
            {
                    GemSound.Play();
                    gems += count;
                    break;
            }
           
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
