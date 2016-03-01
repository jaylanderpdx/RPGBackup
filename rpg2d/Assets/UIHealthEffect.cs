using UnityEngine;
using System.Collections;
using CharacterControl;
public class UIHealthEffect : MonoBehaviour {



    public GameObject effectPrefab;
    GameObject created;
    public BaseCharacterController character;
    
    float lowHealthPercent = .3f;

    public static UIHealthEffect instance;
    // Use this for initialization
	void Start () {
        instance = this;
	
	}

   public void PlayerDiedEffect()
    {

        GameObject obj = Instantiate(effectPrefab);


        RectTransform rect = obj.GetComponent<RectTransform>();
        Transform parent = gameObject.transform.parent;
        GameObject UI = parent.gameObject;
        GameObject canvas = UI.GetComponent<Canvas>().gameObject;
        GameObject EffectContainer = canvas.transform.Find("Effects").gameObject;

        obj.transform.SetParent(EffectContainer.transform);
        SpriteEffect spriteEffect = obj.GetComponent<SpriteEffect>();
        spriteEffect.colorEffect = Color.white;
        spriteEffect.colorEffect.a = .6f;
        spriteEffect.colorTime = 1f;
        rect.localPosition = parent.localPosition;
        rect.localScale = parent.localScale;
        rect.localRotation = parent.localRotation;


    }

    // Update is called once per frame
    void Update ()
    {
        PlayerStats stats = character.playerStats;

        float ratio = stats.currentHealth / stats.maxHealth;



        if (ratio <= lowHealthPercent)
        {
           
            if (!created)
            {

                created = Instantiate(effectPrefab);
                
           
               RectTransform rect = created.GetComponent<RectTransform>();
                Transform parent = gameObject.transform.parent;
                GameObject UI = parent.gameObject;
                GameObject canvas = UI.GetComponent<Canvas>().gameObject;
                GameObject EffectContainer = canvas.transform.Find("Effects").gameObject;

                created.transform.SetParent(EffectContainer.transform);
                rect.localPosition = parent.localPosition;
                rect.localScale = parent.localScale;
                rect.localRotation = parent.localRotation;

                
   
                        }
        }

        else
        {
          
            Destroy(created);
        }
    }
}
