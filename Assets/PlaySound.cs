using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour

{
    public AudioSource Sound;
    // Start is called before the first frame update
    public void SoundPlay()
    {
        Sound.Play();
    }
   
}
