using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour {

    public AudioSource golfSound;
    public AudioSource crystalSound;
    public AudioSource glassSound;
    public AudioSource paintSound;

    public void playGolfSound()
    {
        golfSound.Play();
    }

    public void playCrystalSound()
    {
        crystalSound.Play();
    }

    public void playGlassSound()
    {
        glassSound.Play();
    }

    public void playPaintSound()
    {
        paintSound.Play();
    }

}
