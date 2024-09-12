using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private Animator animator;
    [SerializeField] private float player_speed,player_jump_force;
    [SerializeField] private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        PlayerMovement(horizontal, vertical);
        PlayerAnimation(horizontal,vertical);
    }

    //Player Movement
    void PlayerMovement(float horizontal,float vertical)
    {
        //Horizontal Movement
        Vector2 player_position = transform.position;
        player_position.x = player_position.x + horizontal * player_speed * Time.deltaTime;
        transform.position = player_position;

    }

    //Player Animation
    void PlayerAnimation(float horizontal,float vertical)
    {

        animator.SetFloat("speed",Mathf.Abs(horizontal));

        Vector2 scale = transform.localScale;
        if (horizontal < 0f)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("crouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("crouch", false);
        }

        if(vertical>0)
        {
            animator.SetBool("jump", true);
        }
        else 
        {
            animator.SetBool("jump", false);

        }


        transform.localScale = scale;
    }
}
