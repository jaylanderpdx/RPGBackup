using UnityEngine;
using System.Collections;

public enum PlayerTypes
{
    None,
    MainCharacter,
    Monster,
    Spider,
    Snake,
    NPC

} 

public class PlayerStats: MonoBehaviour
{




    public int currentHealth = 2;
    public int maxHealth = 5;
    
    
    void Start()
    {
        currentHealth = maxHealth;
    }

}
