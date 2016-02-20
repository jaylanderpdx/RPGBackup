using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour
{


    public float moveRadius;
    public float moveSpeed;
  
    AudioSource asource;
    // Use this for initialization

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            CurrencyScript.Instance.PickupCoin(CurrencyScript.CurrencyTypes.Gem, 1);
            GameObject parent = gameObject.transform.parent.gameObject;
            Destroy(parent);

        }
    }

   
    void Start()
    {
        asource = GetComponent<AudioSource>();

       


    }



    // Update is called once per frame
    void Update()
    {

    }
}
