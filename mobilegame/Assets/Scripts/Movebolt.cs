using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movebolt : MonoBehaviour
{
    private Rigidbody rig;
    public float speed;
    void Awake()
    {
        rig = GetComponent<Rigidbody>();   
    }

    void Update()
    {
        rig.velocity = transform.right * -speed;
    }
}
