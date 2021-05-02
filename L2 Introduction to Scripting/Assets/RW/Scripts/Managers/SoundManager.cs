using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //esto sirve para que sea accesible desde otros scrips
    public static SoundManager Instance; // 1
    //efectos de sonido
    public AudioClip shootClip; // 2
    public AudioClip sheepHitClip; // 3
    public AudioClip sheepDroppedClip; // 4
    //posicion de la camara
    private Vector3 cameraPosition; // 5

    //Se usa awake en vez de start cuando se quiere iniciar referencias, ya 
    //que tecnicamente se executa antes de Start
    void Awake()
    {
        Instance = this; // 1
        cameraPosition = Camera.main.transform.position; // 2
    }

    private void PlaySound(AudioClip clip) // 1
    {
        AudioSource.PlayClipAtPoint(clip, cameraPosition); // 2
    }

    public void PlayShootClip()
    {
        PlaySound(shootClip);
    }

    public void PlaySheepHitClip()
    {
        PlaySound(sheepHitClip);
    }

    public void PlaySheepDroppedClip()
    {
        PlaySound(sheepDroppedClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
