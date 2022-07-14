using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
public class Move : MonoBehaviour { 
    public int speed = 300;
    bool isMoving = false;
    
    bool CanMove = true;

    public static Vector2 WorldPos;
    Vector3 StartPos;

    void Start()
    {
        
        StartPos = new Vector2(transform.position.x,transform.position.z);
        WorldPos = new Vector2(0,0);
    }

    void Update() {
        if (isMoving) {
            return;
        }

        else if(Gamepad.current.dpad.x.ReadValue() == 1 && Gamepad.current.dpad.IsPressed() && CanMove == true)
        {
            Debug.Log("LeftBtn");
            CanMove = false;   
            StartCoroutine(Roll(Vector3.left));
        }else if(Gamepad.current.dpad.y.ReadValue() == -1 && Gamepad.current.dpad.IsPressed())
        {
            Debug.Log("UpBtn");
            CanMove = false;
            StartCoroutine(Roll(Vector3.forward));
        }
        else if(Gamepad.current.dpad.x.ReadValue() == -1 && Gamepad.current.dpad.IsPressed())
        {
            Debug.Log("RightBtn");
            CanMove = false;
             StartCoroutine(Roll(Vector3.right));
        }
        else if(Gamepad.current.dpad.y.ReadValue() == 1 && Gamepad.current.dpad.IsPressed())
        {
            Debug.Log("DownBtn");
            CanMove = false;
            StartCoroutine(Roll(Vector3.back));
        }
        else
        {
            CanMove = true;
        }
        GridPosition();
    }

    void GridPosition()
    {
        int WorldPos_X = Mathf.Abs(Mathf.FloorToInt(gameObject.transform.position.x - StartPos.x)) ;
        int WorldPos_Y = Mathf.Abs(Mathf.FloorToInt(gameObject.transform.position.z - StartPos.y)) ;
        WorldPos = new Vector2(WorldPos_X / 2,WorldPos_Y / 2);
        Debug.Log("WorldPos"+WorldPos);
        
       
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