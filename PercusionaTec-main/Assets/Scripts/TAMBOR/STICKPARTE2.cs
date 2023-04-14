using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script que borra una mano transcurrida la m?sica y pone otra
 * Autores: Erika Marlene Garc?a S?nchez, C?sar Emiliano Palome Luna, Jose Angel Garcia Gomez y Jos? Luis Madrigal S?nchez
 */

public class STICKPARTE2 : MonoBehaviour
{

    //Animator
    private Animator animator;

    //Para el animator
    bool sonido2 = false;

    //IsPlaying
    public AudioClip otherClip;
    AudioSource audioSource;

    public bool visibilidadStick = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            sonido2 = true;
            audioSource.Play(0);
            visibilidadStick = false;
        }

        if (!audioSource.isPlaying)
        {
            sonido2 = false;
            //audioSource.Stop();
            if (visibilidadStick == false)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }



    }

    private void FixedUpdate()
    {
        //Animator

        animator.SetBool("sonido2", sonido2);

    }
}
