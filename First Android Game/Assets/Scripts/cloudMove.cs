using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMove : MonoBehaviour
{
    public float speed = 4f;

    private void Update()
    {
        transform.Translate(0f, -speed * Time.deltaTime, 0f);
    }
}
