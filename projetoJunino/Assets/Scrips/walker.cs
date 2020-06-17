﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walker : MonoBehaviour
{
	public float movingSpeed; //velocidade que seu personagem vai andar
	
	//variaveis do pulo
	[Range(0,100)]
    public float jumpVariable = 10f; 
    public float fallVariable = 2.5f;
    public float lowJumpVariable = 2f;
	public float timeElapsedByPress = 0f;
	public float jumpTimeThreshhold = 0.085f;

	private bool isFacingRight = true;

	//objetos (GameObjects ou Components)
	public GameObject player; //objeto do seu personagem
	public BoxCollider2D cc; //pegar o box collidar do seu objeto
	private Rigidbody2D rb;
	public LayerMask groundMask;

	void Awake()
	{
		 cc = GetComponent<BoxCollider2D>();
		 rb = GetComponent<Rigidbody2D>();
	}

    void Start()
    {
        movingSpeed = 3f; //criando automaticamente uma velocidade pro seu personagem
    }

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
            player.transform.Translate(Input.GetAxis("Horizontal")*movingSpeed*Time.deltaTime, 0, 0);
            //muda o transform do personagem de posição
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
        groundMask = 1 << 8;
        float extraHeightText = 0.1f;
        RaycastHit2D hit = Physics2D.Raycast(cc.bounds.center, Vector2.down, cc.bounds.extents.y + extraHeightText, groundMask);
        //origem, direção, extensão, o que vai pegar
        return hit.collider != null;
    }
}