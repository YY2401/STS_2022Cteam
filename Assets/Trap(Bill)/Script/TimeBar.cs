using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    Image m_TimeBar;
    public float currentTime;
    private float maxTime;
    //


    // Start is called before the first frame update
    void Start()
    {
        m_TimeBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float time = maxTime - Time.deltaTime;
    }
}
