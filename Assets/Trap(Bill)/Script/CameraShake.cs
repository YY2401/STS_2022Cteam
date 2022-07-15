using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraShake : MonoBehaviour
{
    public bool isShake;
    public float duration;
    public float magnitude;
    Vector3 first_Pos;

    private void Start()
    {
        first_Pos = this.transform.position;
    }

    public void Update()
    {
        if(isShake)
        {
            Debug.Log("Shake");
           StartCoroutine(Shake());
        }
        else if (isShake == false)
        {
            transform.localPosition = first_Pos;
        }
    }

    public IEnumerator Shake()
    {
        Vector3 originPos = transform.localPosition;

        float elapsed = 0f;

        while(elapsed < duration)
        {
            float x = Random.Range(-1f,1f) * magnitude;
            float y = Random.Range(-1f,1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originPos;
    }    
}
