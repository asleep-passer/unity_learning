using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator playerMove;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public int move_speed;
    public int jump_speed;

    public int rush_speed;
    public float rush_time;
    private float cur_rush_time;
    public float rush_cooldown;
    private float cur_rush_cooldown;

    // Start is called before the first frame update
    void Start()
    {
        playerMove=GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
        sr=GetComponent<SpriteRenderer>();
        cur_rush_cooldown = 0;
        cur_rush_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float input_x = Input.GetAxisRaw("Horizontal");
        if (input_x > 0) sr.flipX = true;
        else if (input_x < 0) sr.flipX=false;
        playerMove.SetInteger("toward",(int)input_x );
        rb.velocity = new Vector2(move_speed * input_x * Time.deltaTime * 100, rb.velocity.y);

        if (Input.GetKey(KeyCode.LeftShift) && cur_rush_cooldown <= 0) 
        {
            cur_rush_cooldown = rush_cooldown;
            cur_rush_time = rush_time;
        }

        if (cur_rush_time>0)
        {
            int dir = 0;
            if (sr.flipX) dir = 1;
            else dir = -1;
            rb.velocity = new Vector2(dir * rush_speed * Time.deltaTime * 100, 0);
            cur_rush_time -= Time.deltaTime;
            
        }
        if (cur_rush_cooldown > 0)
        {
            cur_rush_cooldown -= Time.deltaTime;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        float input_y = Input.GetAxisRaw("Jump");
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jump_speed * input_y * Time.deltaTime * 100);
    }

}
