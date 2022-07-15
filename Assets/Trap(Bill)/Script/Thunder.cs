using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thunder : MonoBehaviour
{

    public float shakeAmount = 0.2f;
    public bool is_Shake = false;
    Vector3 first_Pos;
    public GameObject Traptxt;
    GameObject[] Player;

    // Start is called before the first frame update
    void Start()
    {
        first_Pos = this.transform.localPosition;
        Player = GameObject.FindGameObjectsWithTag("Player");
    }

    
    // Update is called once per frame
    void Update()
    {
        if(is_Shake)
        {
            Vector3 pos = first_Pos + Random.insideUnitSphere * shakeAmount;
            pos.y = transform.localPosition.y;
            transform.localPosition = pos;
        }
        else if (is_Shake == false)
        {
            first_Pos.y = transform.localPosition.y;
            transform.localPosition = first_Pos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("showtxt");
            for (int i = 0; i < Player.Length; i++)
            {
                DamageTxt Dtxt = Instantiate(Traptxt, Player[i].transform.position, Quaternion.identity).GetComponent<DamageTxt>();
            }
        }
    }
}
