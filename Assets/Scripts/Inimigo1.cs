using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inimigo1 : MonoBehaviour
{
    public int velocity = 1;
    private bool colide = false;
    private float move = -2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(move, GetComponent<Rigidbody2D>().velocity.y);
        if (colide)
        {
            Flip();
        }

       
    }

    private void Flip()
    {
        move *= -1;
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        colide = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Plataformas"))
        {
            colide = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataformas"))
        {
            colide = false;
        }
    }
}
