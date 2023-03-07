using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] Color color;

    SpriteRenderer rend;

    [SerializeField]
    private SpriteRenderer tochange;

    // Start is called before the first frame update
    void Start()
    {
        rend =  GetComponent<SpriteRenderer>();
        rend.color = this.color;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        tochange.color = this.color;
    }
}
