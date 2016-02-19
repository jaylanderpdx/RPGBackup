using UnityEngine;

using System.Collections;

public class PlayerController : MonoBehaviour {



    public float moveSpeed = 8.0f; //pixels per second
    Animator anim;
    public static PlayerController Instance;
    public bool isAttacking;
    Rigidbody2D rbod;

    float attackSpeed;
    float attackTimer;

    // Use this for initialization
    void Start() {
        rbod = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Instance = this;
        attackSpeed = .5f;
        attackTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {


        Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (!isAttacking)
        {

            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("attacking");
                isAttacking = true;
            }
            if (Input.GetButtonDown("Fire2"))
            {
                anim.SetTrigger("casting");
            }

            if (move != Vector2.zero)
            {
                anim.SetBool("walking", true);
                anim.SetFloat("move_x", move.x);
                anim.SetFloat("move_y", move.y);
                float x = (move.x * moveSpeed * Time.deltaTime);
                float y = (move.y * moveSpeed * Time.deltaTime);
                transform.Translate(x, y, 0);
            }

            else
                anim.SetBool("walking", false);

        }
        else
        {
            if(attackTimer < attackSpeed)
            {
                attackTimer += Time.deltaTime;
            }
            else
            {
                isAttacking = false;
                attackTimer = 0f;
            }
        }


    }  
}
