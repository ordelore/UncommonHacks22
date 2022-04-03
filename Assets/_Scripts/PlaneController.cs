using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 velocity;
    Vector3 rotation;

    [SerializeField] float ACCEL_SCALE;
    [SerializeField] float DRAG_SCALE;

    void Start()
    {
        velocity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotation += new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));

        transform.position += velocity * Time.deltaTime;
        transform.Rotate(new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal")));
    }

}
