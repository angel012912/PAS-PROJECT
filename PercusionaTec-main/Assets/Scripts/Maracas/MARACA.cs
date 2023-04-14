using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script que comienza reproduccion de secuencia de maracas.
 * Autores: Erika Marlene Garc�a S�nchez, C�sar Emiliano Palome Luna, Jose Angel Garcia Gomez y Jos� Luis Madrigal S�nchez
 */

public class MARACA : MonoBehaviour
{
    //Animator
    private Animator animator;

    //Para el animator
    public bool sonido = false;

    //IsPlaying
    public AudioClip otherClip;
    AudioSource audioSource;

    public bool visibilidadStick = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        animator.SetBool("sonido", sonido);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            sonido = true;
            animator.SetBool("sonido", sonido);
            audioSource.Play(0);
            visibilidadStick = false;
        }

        if (!audioSource.isPlaying)
        {
            sonido = false;
            animator.SetBool("sonido", sonido);
            //audioSource.Stop();
            if (visibilidadStick == false)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
