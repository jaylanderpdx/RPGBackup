using UnityEngine;
using System.Collections;
using CharacterControl;

public class AttackableBreak : Attackable {

    SpriteRenderer renderReference;
    Collider2D colliderReference;
    public Sprite breakSprite;


	void Awake()
    {
        renderReference = GetComponent<SpriteRenderer>();
        colliderReference = GetComponent<Collider2D>();
    }
    // Use this for initialization
	void Start () {
	
	}

    public override void OnAttack(BaseCharacterController Attacker)
    {

        if(colliderReference)
        {
            colliderReference.enabled = false;
            
        }

        renderReference.sprite = breakSprite;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
