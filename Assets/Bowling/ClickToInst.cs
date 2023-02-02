using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToInst : MonoBehaviour
{

    public GameObject SpherePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Camera cam = Camera.main;
            RaycastHit hit;
            if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 1000))
            {
                Vector3 point = hit.point;
                Instantiate(SpherePrefab, point + Vector3.up, Quaternion.identity);
            }
        }
    }
}
