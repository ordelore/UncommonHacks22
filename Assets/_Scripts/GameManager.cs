using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public CameraPositions camPositions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the player presses the spacebar, then we want to switch the camera position
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // We want to switch the camera position
            camPositions.NextPosition();
        }
        
        // Go to space when you hit the 1 key.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("EarthSimpleScene1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
          SceneManager.LoadScene("NewYork");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
          SceneManager.LoadScene("KinectHolographic");
        }
    }
}
