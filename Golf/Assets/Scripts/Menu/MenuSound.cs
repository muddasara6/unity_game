using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour {

    public AudioSource menuSound;

    void Start()
    {
        
    }

    public void playMenuSound()
    {
        menuSound.Play();
    }

}
