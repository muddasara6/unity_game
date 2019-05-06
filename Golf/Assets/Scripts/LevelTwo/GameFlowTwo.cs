using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFlowTwo : MonoBehaviour {

    public static int Course = 0;
    public static int remCourse = 7;
    public Text currentStrokes;
    public Text remainingStrokes;
    private Scene scene;

    // Use this for initialization
    void Start () {
        scene = SceneManager.GetActiveScene();
    }
	
	// Update is called once per frame
	void Update () {
        currentStrokes.GetComponent<Text>().text = "Stroke : " + Course.ToString();
        remainingStrokes.GetComponent<Text>().text = "Remaining : " + remCourse.ToString();
        if(remCourse == 0)
        {
            SceneManager.LoadScene("FailTwo");
            remCourse = 7;
            Course = 0;
        }
    }
}