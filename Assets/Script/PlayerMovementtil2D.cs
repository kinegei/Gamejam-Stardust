using System;
using UnityEngine;
using System.Collections;

public class PlayerMovementtil2D : MonoBehaviour
{
    public float Speed = 1f;
    public float JumpSpeed = 1f;
    public Vector2 Jump;
   
    public bool _isGrounded;

    public Transform Grounder;
    public float Radius;
    public LayerMask Ground;

    private Rigidbody2D _body;
    private Animator animator;
    private Transform[] children;
    private bool Climbing = false;

    private bool Dead = false;
   
    private Single TimeOfDeath;

    // Use this for initialization
    void Start ()
	{
	    _body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

         children = new Transform[transform.childCount];

        int i = 0;
        foreach (Transform T in transform)
            children[i++] = T;
    }
	
	// Update is called once per frame
	void Update () {
	    if (!Dead)
	    {
	        var anim = "StandingStill_";
            transform.DetachChildren();
	        if (Input.GetKey(KeyCode.RightArrow) && _isGrounded)
	        {
	            _body.velocity = new Vector2(Speed, _body.velocity.y);
	            transform.localScale = new Vector3(1, 1, 1);
	            anim = "Running_";
	        }
	        else if (Input.GetKey(KeyCode.LeftArrow) && _isGrounded)
	        {
	            _body.velocity = new Vector2(-Speed, _body.velocity.y);
	            transform.localScale = new Vector3(-1, 1, 1);
	            anim = "Running_";
	        }
	        else if (Input.GetKey(KeyCode.RightArrow) && !_isGrounded)
	        {
	            _body.velocity = new Vector2(JumpSpeed, _body.velocity.y);
	            transform.localScale = new Vector3(1, 1, 1);
	            anim = "Running_";
	        }
	        else if (Input.GetKey(KeyCode.LeftArrow) && !_isGrounded)
	        {
	            _body.velocity = new Vector2(-JumpSpeed, _body.velocity.y);
	            transform.localScale = new Vector3(-1, 1, 1);
	            anim = "Running_";
	        }else if (Climbing && Input.GetKey(KeyCode.UpArrow))
            {
                _body.velocity = new Vector2(_body.velocity.x, 3);
            }
            else if (Climbing && Input.GetKey(KeyCode.DownArrow))
            {
                _body.velocity = new Vector2(_body.velocity.x, -3);
            }else if (Climbing)
            {
                _body.velocity = new Vector2(0, 0);
            }
            else
	        {
	            _body.velocity = new Vector2(0, _body.velocity.y);
	            anim = "StandingStill_";
	        }

	        foreach (Transform T in children) // Re-Attach
	            T.parent = transform;

            
            _isGrounded = Physics2D.OverlapCircle(Grounder.transform.position, Radius, Ground);

	        if (Input.GetKey(KeyCode.Space) && _isGrounded)
	        {
	            _body.AddForce(Jump, ForceMode2D.Force);
	        }

            if (Input.GetKey(KeyCode.S))
            {
                anim = "FlashFire_1_";
            }


            animator.Play(anim);
	    }
	    else
	    {
	        if (TimeOfDeath + 1 < Time.realtimeSinceStartup)
	        {
	            Application.LoadLevel(0);
	        }
	    }
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(Grounder.transform.position, Radius);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Spiketag")
        {
            animator.Play("Death_Animation_");
            Dead = true;
            Debug.Log("Dead");
            TimeOfDeath = Time.realtimeSinceStartup;
        }

        if (other.tag == "ClimbTree")
        {
            Climbing = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "ClimbTree")
        {
            Climbing = false;
        }
    }
}
