using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : Buff
{
    private void Start() {
        GetComponent<CharacterMovement2D>().SpeedBuff = this;
    }

    private void OnDestroy() {
        GetComponent<CharacterMovement2D>().SpeedBuff = null;
    }
}
