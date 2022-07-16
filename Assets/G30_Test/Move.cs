using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Events;
public class Move : MonoBehaviour {
    public GameObject ThisPlayerOBJ;
    public GameObject Steper;
    public MapSpawner mapspawn;
    public Material[] ColorMats;
    public bool[] IsPlayer = new bool[4];//前方偵測玩家(順序：前、後、左、右)
    public Text[] Prop_Name = new Text[4];
    public int speed = 300;
    bool isMoving = false;
    bool CanMoveVer = true;
    bool CanMoveHor = true;
    public  Vector2 WorldPos;
    Vector3 StartPos;
    public bool ThunderTrigger = false;
    public Player ThisPlayer;//這個玩家
    public NowColor ThisColor;
    public bool IsToEnd = false;
    public GamePadRes Controller;private Move Another;
    public GameController GM;
    void Start()
    {
        GM = GameObject.Find("GameController").GetComponent<GameController>();
        CheckCollision(ThisPlayer);
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
    public void CheckCollision(Player _Player)
    {
        if (_Player == Player.Player1)
        {
            Another = GM.Player2;
        }
        else
        {
            Another = GM.Player1;
        }
    }
    public void ColorUpdate()
    {
        this.gameObject.GetComponent<MeshRenderer>().material = ColorMats[(int)ThisColor];
    }
    void Update() {
        ColorUpdate();
        Steper.transform.position = this.transform.position - new Vector3(0, 1, 0);
        if (isMoving) {
            return;
        }
        if (ThunderTrigger)
        {
            return;
        }
        else if(Controller.LeftDpad.ReadValue().x == 1 && CanMoveVer == true )
        {
            Debug.Log(this.gameObject.name+"LeftBtn");
            //Debug.Log(WorldPos+new Vector2(1,0));
            if(mapspawn.GetType(WorldPos+new Vector2(1,0))==BlockType.Wall )
            {
            return;
            }
            if (WorldPos + new Vector2(1, 0) == Another.WorldPos)
            {
                return;
            }
            CanMoveVer = false;
            StartCoroutine(Roll(Vector3.left));
        }else if(Controller.LeftDpad.ReadValue().y == -1 && CanMoveHor == true)
        {
            Debug.Log(this.gameObject.name+"UpBtn");
            //Debug.Log(WorldPos+new Vector2(0,-1));
            if(mapspawn.GetType(WorldPos+new Vector2(0,-1))==BlockType.Wall)
            {
            return;
            }
            if (WorldPos + new Vector2(0, -1) == Another.WorldPos)
            {
                return;
            }
            CanMoveHor = false;
            StartCoroutine(Roll(Vector3.forward));
        }
        else if(Controller.LeftDpad.ReadValue().x == -1 && CanMoveVer == true )
        {
            Debug.Log(this.gameObject.name+"RightBtn");
           //Debug.Log(WorldPos+new Vector2(-1,0));
            if(mapspawn.GetType(WorldPos+new Vector2(-1,0))==BlockType.Wall)
            {
            return;
            }
            if (WorldPos + new Vector2(-1, 0) == Another.WorldPos)
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
            if (WorldPos + new Vector2(0, 1) == Another.WorldPos)
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
    public void ChangeColor()
    {
        if (ThisColor == NowColor.Red)
        {
            ThisColor = NowColor.Blue;
        }
        else
        {
            ThisColor = NowColor.Red;
        }
    }
    public void OnFireTrigger()
    {
        GM.ReducePlayTimer(3f);
    }
    public void OnThunderTrigger(GameObject ThunderParticle)
    {
        if (ThisPlayer == Player.Player1)
        {
            GM.Player2.ThunderTrigger = true;
            Instantiate(ThunderParticle, GM.Player2.ThisPlayerOBJ.transform.position, Quaternion.identity);
            Invoke("Mahi", 2f);
        }
        else
        {
            GM.Player1.ThunderTrigger = true;
            Instantiate(ThunderParticle, GM.Player1.ThisPlayerOBJ.transform.position, Quaternion.identity);
            Invoke("Mahi", 2f);
        }
    }
    public void OnMistTrigger()
    {
        Debug.Log(12345);
        GM.Player1.ThisPlayerOBJ.GetComponent<MeshRenderer>().enabled = false;
        GM.Player2.ThisPlayerOBJ.GetComponent<MeshRenderer>().enabled = false;
        GM.Player1.Steper.SetActive(true);
        GM.Player2.Steper.SetActive(true);
        Invoke("ShowMesh", 2f);
    }
    void ShowMesh()
    {

        GM.Player1.ThisPlayerOBJ.GetComponent<MeshRenderer>().enabled = true;
        GM.Player2.ThisPlayerOBJ.GetComponent<MeshRenderer>().enabled = true;
        GM.Player1.Steper.SetActive(false);
        GM.Player2.Steper.SetActive(false);
    }
    void Mahi()
    {        
        ThunderTrigger = false;
        if (ThisPlayer == Player.Player1)
        {
            GM.Player2.ThunderTrigger = false;
        }
        else
        {
            GM.Player1.ThunderTrigger = false;
        }
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
        SEManager.instance.OnMove();
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
public enum NowColor
{
    Red,
    Blue,
}