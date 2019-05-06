// A generic collection
using System.Collections;
using System.Collections.Generic;
// Scene management at run-time
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {


    public void clickStartGame() {
        // Open Ball scene
        SceneManager.LoadScene("Ball");
    }

}
