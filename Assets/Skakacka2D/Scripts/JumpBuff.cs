using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBuff : Buff
{
    private void Start() {
        GetComponent<CharacterMovement2D>().JumpBuff = this;
    }

    private void OnDestroy() {
        GetComponent<CharacterMovement2D>().JumpBuff = null;
    }
}
