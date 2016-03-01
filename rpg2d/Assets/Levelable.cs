using UnityEngine;
using System.Collections;
using CharacterControl;
using Design;
public class Levelable : MonoBehaviour {

    public int currentxp;
    BaseCharacterController character;

    //public static int[99] ExperienceToNextLevel;

    // Use this for initialization


    int ExperienceToNextLevel(int level)
    {
        return level * 8;
    }


    void Start () {
        character = CharacterDesign.CharacterModule(gameObject);
	}
	
    void Awake()
    {
        character = CharacterDesign.CharacterModule(gameObject);
    }

	// Update is called once per frame
	void Update ()
    {

        if (currentxp >= ExperienceToNextLevel(character.currentLevel))
        {
            character.currentLevel++;
            character.playerStats.maxHealth += character.playerStats.maxHealth * .5f;
            UIMessage.ShowMessage("Level Up!", Color.yellow, 2f);
            character.playerStats.currentHealth = character.playerStats.maxHealth;
        }
	}
}
