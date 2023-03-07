using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col) {

        var player = col.GetComponent<CharacterMovement2D>();
        if(player != null) {
            //player.AddCoin();
        } else {
            // narazil do toho nìkdo jiný, neøešíme...
            Destroy(gameObject);
        }
    }
}
