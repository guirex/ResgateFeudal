using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject MenuPausa;
    public bool Pausado = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pausa()
    {
        if (Pausado)
        {
            MenuPausa.SetActive(true);
            Pausado = false;
        }
        else
        {
            MenuPausa.SetActive(false);
            Pausado = true;
        }
    }
}
