using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using System.Linq;
using UnityEngine.UI;
public class Move : MonoBehaviour { 
    public MapSpawner mapspawn;
    public int speed = 300;
    bool isMoving = false;
    bool CanMoveVer = true;
    bool CanMoveHor = true;
    public  Vector2 WorldPos;
    Vector3 StartPos;
    public Player ThisPlayer;//這個玩家
    public GamePadRes Controller;


    void Start()
    {
    
        StartPos = new Vector2(transform.position.x,transform.position.z);
        
        switch(ThisPlayer)
        {
            case Player.Player1:
            Controller = GameObject.Find("Player1GamePad").GetComponent<GamePadRes>();
            break;
            case Player.Player2:
            Controller = GameObject.Find("Player2GamePad").GetComponent<GamePadRes>();
            break;
        }

    }

    void Update() {
        if (isMoving) {
            return;
        }

        else if(Controller.LeftDpad.ReadValue().x == 1 && CanMoveVer == true)
        {
            Debug.Log(this.gameObject.name+"LeftBtn");
            //Debug.Log(WorldPos+new Vector2(1,0));
            if(mapspawn.GetType(WorldPos+new Vector2(1,0))==BlockType.Wall)
            {
            return;
            }
            CanMoveVer = false;   
            Debug.Log(222);
            StartCoroutine(Roll(Vector3.left));
        }else if(Controller.LeftDpad.ReadValue().y == -1 && CanMoveHor == true)
        {
            Debug.Log(this.gameObject.name+"UpBtn");
            //Debug.Log(WorldPos+new Vector2(0,-1));
            if(mapspawn.GetType(WorldPos+new Vector2(0,-1))==BlockType.Wall)
            {
            return;
            }
            CanMoveHor = false;
            StartCoroutine(Roll(Vector3.forward));
        }
        else if(Controller.LeftDpad.ReadValue().x == -1 && CanMoveVer == true)
        {
            Debug.Log(this.gameObject.name+"RightBtn");
           //Debug.Log(WorldPos+new Vector2(-1,0));
            if(mapspawn.GetType(WorldPos+new Vector2(-1,0))==BlockType.Wall)
            {
            return;
            }
            CanMoveVer = false;
             StartCoroutine(Roll(Vector3.right));
        }
        else if(Controller.LeftDpad.ReadValue().y == 1 && CanMoveHor == true)
        {
            Debug.Log(this.gameObject.name+"DownBtn");
            //Debug.Log(WorldPos+new Vector2(0,1));
            if(mapspawn.GetType(WorldPos+new Vector2(0,1))==BlockType.Wall)
            {
            return;
            }
            CanMoveHor = false;
            StartCoroutine(Roll(Vector3.back));
        }
        if(Controller.LeftDpad.ReadValue().x<=0.85&&Controller.LeftDpad.ReadValue().x>=-0.85&&CanMoveVer == false)
        {
            CanMoveVer = true;
        }
        if(Controller.LeftDpad.ReadValue().y<=0.85&&Controller.LeftDpad.ReadValue().y>=-0.85&&CanMoveHor == false)
        {
            CanMoveHor = true;
        }
        GridPosition();
    }

    void FixedUpdate()
    {
        
    }


    void GridPosition()
    {
        int WorldPos_X = Mathf.RoundToInt(gameObject.transform.position.x * -1)/ 2;
        int WorldPos_Y = Mathf.RoundToInt(gameObject.transform.position.z * -1) / 2;
        WorldPos = new Vector2(1+WorldPos_X ,1+WorldPos_Y );
        //Debug.Log("WorldPos"+WorldPos);
        //Debug.Log("WorldPosX"+WorldPos_X);
        
       
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
[System.Serializable]
public enum Player
{
Player1,
Player2,
}