using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script que borra una mano transcurrida la música y pone otra
 * Autores: Erika Marlene García Sánchez, César Emiliano Palome Luna, Jose Angel Garcia Gomez y José Luis Madrigal Sánchez
 */
public class ManoDer : MonoBehaviour
{
    [SerializeField]

    //Animator
    private Animator animator;

    //Para el animator
    public bool sonido = false;

    public GameObject der2;

    //IsPlaying
    public AudioClip otherClip;
    AudioSource audioSource;


    public bool visibilidadMano = true;


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
            sonido = true;
            animator.SetBool("sonido", sonido);
            audioSource.Play(0);
            visibilidadMano = false;
            
        }

        if (!audioSource.isPlaying)
        {
            sonido = false;
            //audioSource.Stop();
            if (visibilidadMano == false)
            {
                der2.SetActive(true);
                //gameObject.transform.GetChild(0).gameObject.SetActive(true);
                GetComponent<SpriteRenderer>().enabled = false;


            }
            animator.SetBool("sonido", sonido);
        }
    }



}


