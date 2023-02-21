using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement2D : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private Transform groundChecker;

    bool isGrounded = false;
    bool jumpedInAir = false;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

        CheckGrounded();

        float xMove = 0;

        if (Input.GetKey(KeyCode.A)) {
            xMove = -speed;
        }
        if (Input.GetKey(KeyCode.D)) {
            xMove = speed;
        }

        if(Input.GetKeyDown(KeyCode.W)) {
            if(isGrounded) {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpedInAir = false;
            } else if(!jumpedInAir) {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                jumpedInAir = true;
            }
        }

        rb.velocity = new Vector2(xMove, rb.velocity.y);
    }

    // LAYER MASK! Physics2D raycast public layermask

    void CheckGrounded() {
        var hit = Physics2D.Raycast(groundChecker.position, Vector2.down, 0.1f);
        if(hit.collider != null) {
            Debug.Log(hit.collider);
            isGrounded = true;
            jumpedInAir = false;
        } else {
            isGrounded = false;
        }
    }
}
