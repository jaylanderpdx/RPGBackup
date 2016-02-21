using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour {


    public Image healthbarImage;
    public PlayerStats healthStats;
    public Text healthText;
    // Use this for initialization

    void Awake()
    {
      healthStats = GetComponent<PlayerStats>();

       // if(!healthText)
      //  healthText = GetComponent<Text>();
    }
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {



        Transform obj = healthbarImage.gameObject.transform;



        float ratio = (float)(healthStats.currentHealth) / (float)(healthStats.maxHealth);
        obj.localScale = new Vector3(ratio, obj.localScale.y, obj.localScale.z);

        if (healthText)
        {
            float fraction = (ratio * 100.00f);
            int percent = (int)fraction;
            healthText.text = fraction.ToString() + "%";

        }
    }
}
