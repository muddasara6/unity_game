using System.Collections;
using UnityEngine;
// Scene management at run-time
using UnityEngine.SceneManagement;

public class HitBallOne : MonoBehaviour {

    // Power on the shot
    public float zForce = 0;
    // MainCamera in game
    public Camera frontCam;
    // Arrow to move ball
    public Transform aimArrow;
    // Increase size of arrow
    public float yScale = 2;
    // The different ball types
    public Material golfBall;
    public Material crystalBall;
    public Material glassBall;
    public Material paintBall;
    // Add audio file name
    public AudioSource hitBallSound;

    // Use this for initialization
    void Start () {
        // If the player choose this ball
        if (ColorBall.selectedColor == "Golf")
        {
            // Set the material on the ball object 
            GetComponent<Renderer>().material = golfBall;
        }
        if (ColorBall.selectedColor == "Crystal")
        {
            GetComponent<Renderer>().material = crystalBall;
        }
        if (ColorBall.selectedColor == "Glass")
        {
            GetComponent<Renderer>().material = glassBall;
        }
        if (ColorBall.selectedColor == "Paint")
        {
            GetComponent<Renderer>().material = paintBall;
        }
    }
	
	// Update is called once per frame
	void Update () {
        // This code is to add more power to the ball
        // Get the keyboard input
        if(Input.GetKeyDown("w"))
        {
            // Increase the ball power and scale of the arrow y-axis by 1
            zForce += 3000;
            yScale += 1;
            // If the power is greater than 19000, then stop the player from adding any more power
            if (zForce > 19000)
            {
                // Keep the power and scale of the arrow at this position
                zForce = 19000;
                yScale = 8;
            }
            // This stops the player from increasing the Arrow scale, as this is the maximum amount of power the player can apply to the ball
            aimArrow.GetComponent<Transform>().localScale = new Vector3(2, yScale, 2);
        }
        // This code is to add less power to the ball
        if (Input.GetKeyDown("s"))
        {
            // Decrease the ball power and scale of the arrow y-axis by -1
            zForce -= 3000;
            yScale -= 1;
            if (zForce < 1000)
            {
                // If the power is less than 1000, then stop the player from adding any less power
                zForce = 1000;
                yScale = 2;
            }
            aimArrow.GetComponent<Transform>().localScale = new Vector3(2, yScale, 2);
        }
        // This code is to move the ball to the right
        if (Input.GetKey("d"))
        {
            // Rotate the arrow
            transform.Rotate(0, 2, 0); 
        }
        // This code is to move the ball to the left
        if (Input.GetKey("a"))
        {
            transform.Rotate(0, -2, 0);
        }
        // Camera will move with the ball
        frontCam.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;    
    }

    void OnMouseDown()
    {
        // Add force to ball by clicking on it with the mouse
        GetComponent<Rigidbody>().AddRelativeForce(0, 0, zForce);
        // While the ball is moving, the arrow will disappear
        aimArrow.GetComponent<Renderer>().enabled = false;
        // Increase the number of strokes displayed on the canvas
        GameFlowOne.Course += 1;
        // Decrease the number of remaining strokes displayed on the canvas
        GameFlowOne.remCourse -= 1;
        // This is will occur before the ball stops moving
        StartCoroutine(stopBall());
        // Play the sound
        hitBallSound.Play();
    }

    // Collider involved in this collision
    void OnTriggerEnter(Collider other)
    {
        // If the ball hits the Cup object
        if(other.name == "Cup")
        {
            // The Pass scene will open
            SceneManager.LoadScene("PassOne");
        }
        // If the ball goes out of bounds
        if (other.name == "OutOfBounds")
        {
            // Reload the game
            SceneManager.LoadScene("LevelOne");
        }
    }

    // IEnumerator is the base interface for all non-generic enumerators
    IEnumerator stopBall()
    {
        // The player will have to wait five seconds before they can hit the ball again
        yield return new WaitForSeconds(5);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(.1f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        transform.localEulerAngles = new Vector3(0, 0, 0);
        // Once the ball has stopped moving, the arrow will reappear again
        aimArrow.GetComponent<Renderer>().enabled = true;
    }
}
