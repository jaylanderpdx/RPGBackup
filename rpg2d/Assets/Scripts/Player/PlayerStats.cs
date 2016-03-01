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




    public float currentHealth = 2;
    public float maxHealth = 5;
    public int strength = 2;
    public int basedamage = 1;
    public float critical = .2f;
    public float hit = .8f;

  
    

    public void AddHealth(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;

    }

    void Start()
    {
        currentHealth = maxHealth;
    }

}
