using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Monsters;
using Design;
public class HealthbarController : MonoBehaviour {


    public Image healthbarImage;
    public PlayerStats healthStats;
    public Text healthText;
    // Use this for initialization

    void Awake()
    {
      
      
    }
    void Start () {

       PlayerStats lookup = CharacterDesign.StatsModule(gameObject);

        if (lookup)
            healthStats = lookup;
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
