using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

    
    AudioSource asource;
    // Use this for initialization

        void OnTriggerEnter2D(Collider2D other)
        {
       
            if (other.tag == "Player")
            {
            CurrencyScript.Instance.PickupCoin(CurrencyScript.CurrencyTypes.Gem, 1);
            Destroy(gameObject);
            }
        }

    void Start () {
        asource = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
