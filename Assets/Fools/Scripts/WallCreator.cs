using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreator : MonoBehaviour
{
    [SerializeField]
    private float radius = 4;

    [SerializeField]
    private float density = 2;

    // Start is called before the first frame update
    void Start()
    {
        CreateWalls();
    }

    private void CreateWalls() {
        float x, y;
        GameObject g;

        for (float uhel = 0; uhel <= 360; uhel += density) { 
        
            x = radius * Mathf.Cos(uhel * Mathf.PI / 180);
            y = radius * Mathf.Sin(uhel * Mathf.PI / 180);

            g = GameObject.CreatePrimitive(PrimitiveType.Cube);
            g.transform.position = new Vector3(x, 0.5f, y);
            g.transform.rotation = Quaternion.Euler(0, -uhel ,0);
            g.transform.SetParent(transform);
            g.AddComponent<WallCollision>();
        }
    }
}
