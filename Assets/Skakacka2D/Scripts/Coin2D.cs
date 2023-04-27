using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin2D : MonoBehaviour
{
    Animator animator;

    private void Start() {
        animator= GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col) {

        var player = col.GetComponent<CharacterMovement2D>();
        if(player != null) {
            animator.SetTrigger("Fade");
            Destroy(transform.parent.gameObject, 1f);
            //player.AddCoin();
        } else {
            // narazil do toho nìkdo jiný, neøešíme...
        }
    }
}
