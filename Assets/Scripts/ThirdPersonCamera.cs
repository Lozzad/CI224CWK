using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;
    //references to positions needed
    public Transform lookAt;            //where to look
    public Transform camTransform;      //the cam transform
    private Camera cam;                 //the camera
    private float distance = 10.0f;     //cam distance
    private float currX = 0.0f;         //current X
    private float currY = 0.0f;         //current Y
    private float sensitivityX = 4.0f;  //sensitivity vals
    private float sensitivityY = 1.0f;  //^^

    private void Start() {
        camTransform = transform;
        cam = Camera.main;
    }

    private void Update() {
        currX += Input.GetAxis("Mouse X")*sensitivityX;
        currY += Input.GetAxis("Mouse Y")*sensitivityY;
        currY = Mathf.Clamp(currY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    //use this so the camera reacts to player move
    private void LateUpdate() {
        Vector3 dir = new Vector3(0,0,-distance);
        Quaternion rotation = Quaternion.Euler(currY,currX,0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
