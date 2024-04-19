using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rebote : MonoBehaviour
{
   public GameObject[] hearts;

    [SerializeField] private float vida;

    private playerScript movimientoJugador;

    [SerializeField] private float tiempoPerdida;

    private Animator animator;
    
    void Start()
    {
        movimientoJugador = GetComponent<playerScript>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        if (vida < 1)
        {
            Destroy(hearts[0].gameObject);
        }
        else if (vida < 2)
        {
            Destroy(hearts[1].gameObject);
        }
        else if (vida < 3)
        {
            Destroy(hearts[2].gameObject);
        }
        else if (vida == 0)
        {
            
        }
    }



    public void Rebotar(int da�o, Vector2 posicion)
    {
        vida -= da�o; 
        animator.SetTrigger("Golpe");
        StartCoroutine(PerderControl());
        movimientoJugador.Rebote(posicion);
    }

    public void TomarDa�o(float da�o)
    {
        vida -= da�o;

    }
    private IEnumerator PerderControl()
    {
        movimientoJugador.sePuedeMover = false;
        yield return new WaitForSeconds(tiempoPerdida);
        movimientoJugador.sePuedeMover = true;
    }
}
