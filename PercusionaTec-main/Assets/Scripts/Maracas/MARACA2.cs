using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script que activa movimiento y sonido de maraca izquierda con tecla especifica.
 * Autores: Erika Marlene García Sánchez, César Emiliano Palome Luna, Jose Angel Garcia Gomez y José Luis Madrigal Sánchez
 */

public class MARACA2 : MonoBehaviour
{
    //Animator
    private Animator animator;

    //Para el animator
    public bool accion = false;

    //IsPlaying
    public AudioClip otherClip;
    AudioSource audioSource;



    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        animator.SetBool("accion", accion);
        animator.SetBool("sonido", false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            accion = true;
            animator.SetBool("accion", accion);
            //animator.SetBool("accion", true);
            audioSource.Play(0);

        }

        if (!audioSource.isPlaying)
        {
            accion = false;
            animator.SetBool("accion", accion);
            //animator.SetBool("accion", false);
        }
    }

}
