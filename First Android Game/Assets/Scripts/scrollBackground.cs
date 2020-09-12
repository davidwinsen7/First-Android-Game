using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollBackground : MonoBehaviour
{
    public float speed = -2f;
    public float lowerYValue = -10.24f;
    public float upperYValue = 20.48f;

    private void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f);
        if(transform.position.y <= lowerYValue)
        {
            transform.Translate(0f, upperYValue, 0f);
        }
    }
}
