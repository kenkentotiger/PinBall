using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    // ��]���x
    private float rotSpeed = 0.5f;

    // use this for initialization
    void Start()
    {
        //��]
        this.transform.Rotate(0, Random.Range(0, 360), 0);
    }

    // Update is called once por frame
    private void Update()
    {
        //��]
        this.transform.Rotate(0, this.rotSpeed, 0);
    }
}

