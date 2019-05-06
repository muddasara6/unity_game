using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Ability to use the UI tools
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFlowOne : MonoBehaviour {

    // Set the strokes to zero on the canvas
    public static int Course = 0;
    // Set the remaining strokes to five on the canvas
    public static int remCourse = 5;
    // Get Text from canvas
    public Text currentStrokes;
    public Text remainingStrokes;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        // Set the current strokes to the Text
        currentStrokes.GetComponent<Text>().text = "Stroke : " + Course.ToString();
        // Set the remaining strokes to the Text
        remainingStrokes.GetComponent<Text>().text = "Remaining : " + remCourse.ToString();
        // If the remaining strokes hit zero
        if (remCourse == 0)
        {
            // Load the Fail scene
            SceneManager.LoadScene("FailOne");
            // Reset
            remCourse = 5;
            Course = 0;
        }
    }
}