using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int pulo;
    public int lives;
    public int velocidade;

    public bool isGrounded;

    public Text TextLives;

    void Start()
    {
        pulo = 150;
        velocidade = 1;
        lives = 3;
        TextLives.text = lives.ToString();
    }

    void Update()
    {
        
        Rigidbody2D ri = GetComponent<Rigidbody2D>();

        float movimento = Input.GetAxis("Horizontal");
        ri.velocity = new Vector2(movimento*velocidade, ri.velocity.y);

        if(movimento < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<Animator>().SetBool("Andando", true);

        }
        else if(movimento > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            GetComponent<Animator>().SetBool("Andando", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Andando", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pula();
        }

        if (isGrounded)
        {
            GetComponent<Animator>().SetBool("Jumping", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Jumping", true);
        }
    }

    void pula()
    {
        if(isGrounded == true)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector3(0, pulo));
            GetComponent<Animator>().SetBool("Pulando", true);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Plataformas"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Plataformas"))
        {
            isGrounded = false;
            GetComponent<Animator>().SetBool("Pulando", false);
        }   
    }

}
