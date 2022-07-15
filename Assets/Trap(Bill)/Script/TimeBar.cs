using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    [SerializeField]Image m_TimeBar;
    public float currentTime;   
    public float maxTime;
    public static TimeBar instance;
    //
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_TimeBar = GetComponent<Image>();
        //currentTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
            //currentTime -= Time.deltaTime;
            m_TimeBar.fillAmount = currentTime;
        
    }
}
