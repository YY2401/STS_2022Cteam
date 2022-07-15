using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogTrap : MonoBehaviour
{
    GameObject[] Player;
    GameObject[] Ex;

    public GameObject PS;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        Ex = GameObject.FindGameObjectsWithTag("PS");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            for(int i = 0; i < Player.Length; i++ )
            {
                Player[i].GetComponent<MeshRenderer>().enabled = false;
                Invoke("ShowMesh",1f) ;
                Instantiate(PS,Player[i].transform.position,Player[i].transform.rotation);
            }
        }
    }

    void ShowMesh()
    {
        for (int i = 0; i < Player.Length; i++)
        {
            Player[i].GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
