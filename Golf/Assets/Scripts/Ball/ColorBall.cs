using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorBall : MonoBehaviour {

    public static string selectedColor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void clickGolfBall()
    {
        // Check the selected ball the player has chosen
        selectedColor = "Golf";
        // Load the first level
        SceneManager.LoadScene("LevelOne");
    }

    public void clickCrystalBall()
    {
        selectedColor = "Crystal";
        SceneManager.LoadScene("LevelOne");
    }

    public void clickGlassBall()
    {
        selectedColor = "Glass";
        SceneManager.LoadScene("LevelOne");
    }

    public void clickPaintBall()
    {
        selectedColor = "Paint";
        SceneManager.LoadScene("LevelOne");
    }
}
