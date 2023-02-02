using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Transform t;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float border;

    void Start()
    {
        t = GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 move = Vector3.zero;

        if(Input.GetKey(KeyCode.A))
            move.x = -1;

        if (Input.GetKey(KeyCode.D))
            move.x = 1;

        // (-1,0,0)

        t.position += move * speed * Time.deltaTime;

        // ohranièení herní plochy
        if (t.position.x < -border)
            t.position = new Vector3(-border, t.position.y, t.position.z);
        if (t.position.x > border)
            t.position = new Vector3(border, t.position.y, t.position.z);
    }
}
