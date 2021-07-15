using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    // ‰ñ“]‘¬“x
    private float rotSpeed = 0.5f;

    // use this for initialization
    void Start()
    {
        //‰ñ“]
        this.transform.Rotate(0, Random.Range(0, 360), 0);
    }

    // Update is called once por frame
    private void Update()
    {
        //‰ñ“]
        this.transform.Rotate(0, this.rotSpeed, 0);
    }
}

