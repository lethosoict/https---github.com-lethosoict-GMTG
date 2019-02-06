using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    public VirtualJoystick cameraJoystick;
    public Transform lookAt;

    private float distance = 5.0f;
    private float currentX = 3.0f;
    private float currentY = 10.0f;
    private float sensitivityX = 3.0f;
    private float sensitivityY = 1.0f;

    private void Update()
    {
        currentX += cameraJoystick.InputDirection.x * sensitivityX;
        currentY += cameraJoystick.InputDirection.y * sensitivityY;
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = lookAt.position + rotation * dir;
        transform.LookAt(lookAt);
    }
}
