using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuffCreator : MonoBehaviour
{
    [SerializeField]
    private BuffType buffType;

    [SerializeField]
    private float duration = 5f;

    [SerializeField]
    private float buffForce = 1.2f;

    static Dictionary<BuffType, Type> typeByBuff = new Dictionary<BuffType, Type>() {
        { BuffType.Speed, typeof(SpeedBuff) }
    };

    private void OnTriggerEnter2D(Collider2D col) {
        var player = col.GetComponent<CharacterMovement2D>();
        if (player != null) {

            Buff buff = (Buff)player.gameObject.GetComponent(typeByBuff[buffType]);
            if(buff) {
                buff.Collect(duration, buffType, buffForce);
            } else {
                buff = (Buff) player.gameObject.AddComponent(typeByBuff[buffType]);
                buff.Collect(duration, buffType, buffForce);
            }
        }
    }
}
