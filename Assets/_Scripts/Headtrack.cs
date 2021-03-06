using UnityEngine;
using System.Collections;
using System.IO;

public class Headtrack : MonoBehaviour
{
    public float OffsetX;
    public float OffsetY;
    public float OffsetZ;
    public float MultiplyX = 1f;
    public float MultiplyY = 1f;
    public float MultiplyZ = 1f;
    [SerializeField]
    UDPReceive receiver = null;
    [SerializeField]
    float reductionPositionFactor = 1f;

    [SerializeField]
    float reductionRotationFactor = 1f;

    public ProjectionMatrix projScript;

    void Update()
    {
        //Debug.Log("xPos: " + receiver.xPos + " yPos: " + receiver.yPos + " zPos: " + receiver.zPos);
        transform.position = new Vector3(receiver.xPos * reductionPositionFactor * MultiplyX + OffsetX, receiver.yPos * reductionPositionFactor * MultiplyY + OffsetY, -receiver.zPos * reductionPositionFactor * MultiplyZ + OffsetZ);
        transform.rotation = Quaternion.Euler(receiver.pitch * reductionRotationFactor, receiver.yaw * reductionRotationFactor, receiver.roll * reductionRotationFactor);
        //Quaternion.Euler(0, 0, 0);//
    }
}
