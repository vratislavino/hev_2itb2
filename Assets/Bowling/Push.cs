using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{

    public float force = 100;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.back * force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
