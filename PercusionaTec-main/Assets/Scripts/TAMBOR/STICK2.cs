using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script que borra una mano transcurrida la m?sica y pone otra
 * Autores: Erika Marlene Garc?a S?nchez, C?sar Emiliano Palome Luna, Jose Angel Garcia Gomez y Jos? Luis Madrigal S?nchez
 */

public class STICK2 : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.D))
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
