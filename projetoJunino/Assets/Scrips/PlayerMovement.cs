using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //variaveis
    public float movementSpeed = 5f;

    [Range(0,100)]
    public float jumpVariable = 10f; 
    private float fallVariable = 2.5f;
    private  float lowJumpVariable = 2f;
	private  float timeElapsedByPress = 0f;
	private  float jumpTimeThreshhold = 0.085f;

    private bool isFacingRight = true;

    //referencia de classes
    private GameObject player;
    private Rigidbody2D rb;
	private BoxCollider2D bc;
    public LayerMask groundMask;

    // Awake is called when the script instance is being loaded.
    void Awake()
    {
        player = GameObject.Find("Player");;
        bc = GetComponent<BoxCollider2D>();
		rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetAxis("Horizontal") != 0f) //verifica se o jogador está se movimentando
        {
        	if(Input.GetAxis("Horizontal") > 0f && !isFacingRight && IsGrounded())
        	{
                Flip();
            } else if (Input.GetAxis("Horizontal") < 0f && isFacingRight && IsGrounded())
            {
                Flip();
            }
            player.transform.Translate(Input.GetAxis("Horizontal")*movementSpeed*Time.deltaTime, 0, 0);
        } 

        if(Input.GetKey(KeyCode.Space))
            if(IsGrounded())
                timeElapsedByPress += Time.deltaTime;

        if(timeElapsedByPress >= jumpTimeThreshhold)
        {
            timeElapsedByPress = 0;
            if(IsGrounded())
            {
                rb.velocity += Vector2.up * jumpVariable;
            } else 
            {
            	if(Input.GetKeyUp(KeyCode.Space))
                {
                    if(IsGrounded())
                    {
                        rb.velocity += Vector2.up * jumpVariable * (timeElapsedByPress*10);
                    }
                    timeElapsedByPress = 0;
                }
        	}
    	}

        if(rb.velocity.y < 0)
    	{
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallVariable - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0  && !Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpVariable - 1) * Time.deltaTime;
        }
    }

    void Flip()
	{
        isFacingRight = !isFacingRight;
        Vector3 theScale = this.gameObject.transform.localScale;
        theScale.x *= -1;
        this.gameObject.transform.localScale = theScale;
    }

    bool IsGrounded()
    {
        float extraHeightText = 0.1f;
        RaycastHit2D hit = Physics2D.Raycast(bc.bounds.center, Vector2.down, bc.bounds.extents.y + extraHeightText, groundMask);
        return hit.collider != null;
    }
    
}
