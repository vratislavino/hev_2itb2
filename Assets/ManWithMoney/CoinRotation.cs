using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    Transform t;

    [SerializeField]
    private int speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();    
    }

    // Update is called once per frame
    void Update()
    {
        t.Rotate(0, 0, speed * Time.deltaTime);
    }
}
