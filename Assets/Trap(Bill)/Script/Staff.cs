using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Staff : MonoBehaviour
{
    public TextMeshProUGUI txt;


    private void Start()
    {
        txt.text = GetComponent<TMPro.TextMeshProUGUI>().text;
    }


    public void PGone()
    {
        txt.text = "PG_01 \n KAKERU";
    }
    public void PGtwo()
    {
        txt.text = "PG_02 \n SONARU";
    }
    public void PGthree()
    {
        txt.text = "PG_03 \n YY";
    }
    public void PGfour()
    {
        txt.text = "PG_04 \n Bill_Lin";
    }
    public void ThreeDArt()
    {
        txt.text = "3D \n Kevin";
    }
    public void TwoDArt()
    {
        txt.text = "2D_01 \n Vic";
    }
    public void TwoDArttwo()
    {
        txt.text = "2D_02 \n Ringo";
    }
}
