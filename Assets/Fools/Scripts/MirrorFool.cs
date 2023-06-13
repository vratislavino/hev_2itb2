using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorFool : MoreLivesFool
{
    protected override void MinusLife() {
        base.MinusLife();
        if(currentLives == 1) {
            transform.Rotate(Vector3.up * 180);
            transform.position *= -1; 
        } 
    }
}
