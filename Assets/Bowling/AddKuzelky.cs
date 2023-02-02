using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddKuzelky : MonoBehaviour
{
    public GameObject Kuzelka;

    public int pocetX;
    public int pocetZ;
    public float gap = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i <pocetX; i++)
        {
            for (int j = 0; j < pocetZ; j++)
            {
                Instantiate(Kuzelka, new Vector3(transform.position.x + i * gap, 0, transform.position.z + j * gap), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
