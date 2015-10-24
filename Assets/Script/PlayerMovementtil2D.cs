using UnityEngine;
using System.Collections;

public class PlayerMovementtil2D : MonoBehaviour
{
    public float Speed = 1f;
    public Vector2 Jump;
   
    public bool _isGrounded;

    public Transform Grounder;
    public float Radius;
    public LayerMask Ground;

    private Rigidbody2D _body;
    private Animator animator;

    // Use this for initialization
    void Start ()
	{
	    _body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.RightArrow))
	    {
            _body.velocity = new Vector2(Speed, _body.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
            animator.Play("Running_");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _body.velocity = new Vector2(-Speed, _body.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
            animator.Play("Running_");
        }
        else
        {
            _body.velocity = new Vector2(0, _body.velocity.y);
            animator.Play("StandingStill_");
        }


	    _isGrounded = Physics2D.OverlapCircle(Grounder.transform.position, Radius, Ground);

	    if (Input.GetKey(KeyCode.Space) && _isGrounded)
	    {
            _body.AddForce(Jump, ForceMode2D.Force);
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
            Debug.Log("Dead");
            Application.LoadLevel(0);
        }
    }
}
