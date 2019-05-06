using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassThree : MonoBehaviour {

    public AudioSource clickButton;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void clickLevelFour()
    {
        SceneManager.LoadScene("LevelFour");
    }

    public void clickQuit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void clickOnButton()
    {
        clickButton.Play();
    }
}
