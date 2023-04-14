using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script que controla movimiento del personaje con las teclas.
 * Autores: Erika Marlene García Sánchez, César Emiliano Palome Luna, Jose Angel Garcia Gomez y José Luis Madrigal Sánchez
 */

public class MuevePersonaje : MonoBehaviour
{
    //Velocidades
    public float velocidadX = 0;
    public float velocidadY = 0;

    //RigidBody
    Rigidbody2D rb;

    //Animator
    private Animator animator;

    //Renderer
    private SpriteRenderer rendererPersonaje;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rendererPersonaje = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //Caminar
        float movHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movHorizontal * velocidadX, rb.velocity.y);
        //Saltar
        float movVertical = Input.GetAxis("Vertical");
        if (movVertical > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, movVertical * velocidadY);
        }
        //Animator
        float velocidad = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("velocidad", velocidad);
        //Direccion adecuada
        rendererPersonaje.flipX = rb.velocity.x < 0;
    }

    }
