using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositions : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject[] cameraPositions;
    public int currentPos = 0;

    public static event Action<int> OnCameraPositionChanged;

    // Start is called before the first frame update
    void Start()
    {
        cameraPositions = GameObject.FindGameObjectsWithTag("CameraPosition");
        if (cameraPositions.Length == 0 ){
            Debug.Log("No camera positions found");
        }
        else {
            Debug.Log("Found " + cameraPositions.Length + " camera positions");
        }

        UpdateCameraPosition(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextPosition() {
        if (currentPos < cameraPositions.Length - 1) {
            UpdateCameraPosition(currentPos + 1);
        }
        else {
            UpdateCameraPosition(0);
        }
    }

    public void UpdateCameraPosition(int newPos){

      if (newPos < cameraPositions.Length) {
        currentPos = newPos;
        Transform trans = cameraPositions[currentPos].transform;
        Transform childTrans = trans.Find("ViewPlane");
        Debug.Log("childTrans");
        Debug.Log(childTrans);

        if (childTrans != null) {
          ProjectionMatrix proj = mainCamera.GetComponent("projectionMatrix") as ProjectionMatrix;
          proj.projectionScreen = childTrans.gameObject;
        } else {
          Debug.Log("No Valid Projection Screen");
        }
      }

      else{
        Debug.Log("Invalid Camera Position");
      }
      
      OnCameraPositionChanged?.Invoke(newPos);
    }
}
