using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moss : MonoBehaviour
{
    public float timeToGrow = 1;
    public float growPercentage = 1.4f;

    public float speed = 1;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start() {

        rb = GetComponent<Rigidbody2D>();
        
        StartCoroutine(Grow());
    }

    private IEnumerator Grow() {
        while (true) {
            yield return new WaitForSeconds(timeToGrow);
            var sc = transform.localScale;
            sc.x *= growPercentage;
            transform.localScale = sc;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = 0;

        if (Input.GetKey(KeyCode.LeftArrow)) {
            xMove = -speed;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            xMove = speed;
        }
        rb.velocity = new Vector2(xMove, rb.velocity.y);
    }
}
