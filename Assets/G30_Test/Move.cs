using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
public class Move : MonoBehaviour { 
    public int speed = 300;
    bool isMoving = false;
    Gamepad gamepad;
    void Update() {
        if (isMoving) {
            return;
        }

        else if(Gamepad.current.dpad.x.ReadValue() == -1 && Gamepad.current.dpad.IsPressed())
        {
            Debug.Log("LeftBtn");
            StartCoroutine(Roll(Vector3.left));
        }else if(Gamepad.current.dpad.y.ReadValue() == 1 && Gamepad.current.dpad.IsPressed())
        {
            Debug.Log("UpBtn");
            StartCoroutine(Roll(Vector3.forward));
        }
        else if(Gamepad.current.dpad.x.ReadValue() == 1 && Gamepad.current.dpad.IsPressed())
        {
            Debug.Log("RightBtn");
             StartCoroutine(Roll(Vector3.right));
        }
        else if(Gamepad.current.dpad.y.ReadValue() == -1 && Gamepad.current.dpad.IsPressed())
        {
            Debug.Log("DownBtn");
            StartCoroutine(Roll(Vector3.back));
        }
    }

    IEnumerator Roll(Vector3 direction) {
        isMoving = true;

        float remainingAngle = 90;
        Vector3 rotationCenter = transform.position + direction  + Vector3.down ;
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);

        while (remainingAngle > 0) {
            float rotationAngle = Mathf.Min(Time.deltaTime * speed, remainingAngle);
            transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
            remainingAngle -= rotationAngle;
            yield return null;
        }

        isMoving = false;
    }
}