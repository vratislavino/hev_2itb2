using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PohybKoule : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    private float speed = 1;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (Vector2)Input.mousePosition - new Vector2(Screen.width/2, Screen.height/2);
        direction.Normalize();
        rb.AddForce(new Vector3(direction.x, 0, direction.y) * speed * Time.deltaTime);

        if(Input.GetMouseButtonDown(0)) {
            ResetKoule();
        }
    }

    private void ResetKoule() {
        transform.position = Vector3.zero;
        rb.velocity = Vector3.zero;
    }
}
