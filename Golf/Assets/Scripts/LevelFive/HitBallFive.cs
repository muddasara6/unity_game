using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitBallFive : MonoBehaviour {

    public float zForce = 0;
    public Camera frontCam;
    public Transform aimArrow;
    public float yScale = 2;
    public Material golfBall;
    public Material crystalBall;
    public Material glassBall;
    public Material paintBall;
    public AudioSource hitBallSound;

    // Use this for initialization
    void Start () {
        if (ColorBall.selectedColor == "Golf")
        {
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
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            zForce += 3000;
            yScale += 1;
            if (zForce > 19000)
            {
                zForce = 19000;
                yScale = 8;
            }
            aimArrow.GetComponent<Transform>().localScale = new Vector3(2, yScale, 2);
        }
        if (Input.GetKeyDown("s"))
        {
            zForce -= 3000;
            yScale -= 1;
            if (zForce < 1000)
            {
                zForce = 1000;
                yScale = 2;
            }
            aimArrow.GetComponent<Transform>().localScale = new Vector3(2, yScale, 2);
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(0, 2, 0);
        }
        if (Input.GetKey("a"))
        {
            transform.Rotate(0, -2, 0);
        }
        frontCam.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
    }

    void OnMouseDown()
    {
        GetComponent<Rigidbody>().AddRelativeForce(0, 0, zForce);
        aimArrow.GetComponent<Renderer>().enabled = false;
        GameFlowFive.Course += 1;
        GameFlowFive.remCourse -= 1;
        StartCoroutine(stopBall());
        hitBallSound.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Cup")
        {
            SceneManager.LoadScene("PassFive");
        }
        if (other.name == "OutOfBounds")
        {
            SceneManager.LoadScene("LevelFive");
        }
    }

    IEnumerator stopBall()
    {
        yield return new WaitForSeconds(5);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(.1f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        transform.localEulerAngles = new Vector3(0, 0, 0);
        aimArrow.GetComponent<Renderer>().enabled = true;
    }
}
