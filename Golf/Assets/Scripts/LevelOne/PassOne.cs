// A generic collection
using System.Collections;
using System.Collections.Generic;
// Scene management at run-time
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassOne : MonoBehaviour {

    public AudioSource clickButton;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Declare a method
    public void clickLevelTwo()
    {
        // Open LevelTwo scene
        SceneManager.LoadScene("LevelTwo");
    }

    public void clickQuit()
    {
        // Open Menu scene
        SceneManager.LoadScene("Menu");
    }

    public void clickOnButton()
    {
        clickButton.Play();
    }
}
