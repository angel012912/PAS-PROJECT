using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script que mueve y activa sonido de mano derecha con tecla especifica.
 * Autores: Erika Marlene Garc�a S�nchez, C�sar Emiliano Palome Luna, Jose Angel Garcia Gomez y Jos� Luis Madrigal S�nchez
 */

public class ManoDer2 : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.M))
        {
            accion = true;
            audioSource.Play(0);

        }

        if (!audioSource.isPlaying)
        {
            accion = false;

        }

    }

    private void FixedUpdate()
    {
        //Animator

        animator.SetBool("accion", accion);
    }
}
