using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script que mueve y activa sonido de mano izquierda con tecla especifica.
 * Autores: Erika Marlene García Sánchez, César Emiliano Palome Luna, Jose Angel Garcia Gomez y José Luis Madrigal Sánchez
 */

public class ManoIzq2 : MonoBehaviour
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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            accion = true;
            animator.SetBool("accion", accion);
            audioSource.Play(0);

        }

        if (!audioSource.isPlaying)
        {
            accion = false;

        }
        animator.SetBool("accion", accion);

    }

    private void FixedUpdate()
    {
        //Animator

        animator.SetBool("accion", accion);
    }
}

