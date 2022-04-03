using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositions : MonoBehaviour
{
    public GameObject mainCamera;
    //public GameObject[] cameraPositions;
    public GameObject[] viewPlanes;
    public Headtrack headtrack;
    public int currentPos = 0;

    public static event Action<int> OnCameraPositionChanged;

    // Start is called before the first frame update
    void Start()
    {
        viewPlanes = GameObject.FindGameObjectsWithTag("ViewPlane");
        if (viewPlanes.Length == 0 ){
            Debug.Log("No camera positions found");
        }
        else {
            Debug.Log("Found " + viewPlanes.Length + " camera positions");
        }

        UpdateCameraPosition(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextPosition() {
        if (currentPos < viewPlanes.Length - 1) {
            UpdateCameraPosition(currentPos + 1);
        }
        else {
            UpdateCameraPosition(0);
        }
    }

    public void UpdateCameraPosition(int newPos){
      Debug.Log(newPos);
      if (newPos < viewPlanes.Length) {
        currentPos = newPos;
        //Debug.Log(cameraPositions[newPos]);
        //CameraPosition camPos = cameraPositions[newPos].GetComponent(typeof(CameraPosition)) as CameraPosition;
        ///Debug.Log(camPos);
        // If campos is null, print to log

        GameObject viewPlane = viewPlanes[newPos];
        float Offx = viewPlane.transform.position.x;
        float Offy = viewPlane.transform.position.y;
        float Offz = viewPlane.transform.position.z;

        headtrack.OffsetX = Offx;
        headtrack.OffsetY = Offy;
        headtrack.OffsetZ = Offz;
        Debug.Log("Original Pos: Offx: " + Offx + " Offy: " + Offy + " Offz: " + Offz);
        //viewPlane.transform.eulerAngles.x
        Quaternion eulerRotation = Quaternion.Euler(0, viewPlane.transform.eulerAngles.y, viewPlane.transform.eulerAngles.z);
        Vector3 cameraOffest = new Vector3(0, 0, 0);
        cameraOffest = eulerRotation * cameraOffest;
        Debug.Log(cameraOffest);
        headtrack.OffsetX += cameraOffest.x;
        headtrack.OffsetY += cameraOffest.y;
        headtrack.OffsetX += cameraOffest.z;
        Debug.Log(cameraOffest);



        ProjectionMatrix proj = mainCamera.GetComponent(typeof(ProjectionMatrix)) as ProjectionMatrix;
        proj.projectionScreen = viewPlane;
      }
      else{
        Debug.Log("Invalid Camera Position");
      }
      
      OnCameraPositionChanged?.Invoke(newPos);
    }
}
