using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    Vector3 lastRotation;

    void Start()
    {
        
    }

    void Update()
    {
        //transform.Rotate(new Vector3(0, 1, 0), 10f);

        transform.rotation = Quaternion.Euler(lastRotation + new Vector3(0, 10f, 0));
        lastRotation = transform.eulerAngles;
    }
}
