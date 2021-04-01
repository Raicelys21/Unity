using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    private Rigidbody rig;
    public float speed;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rig.angularVelocity = Random.insideUnitSphere * speed;
    }

}
