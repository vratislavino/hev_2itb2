using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusFool : NormalFool
{
    [SerializeField]
    private float maxAngle;

    [SerializeField]
    private float angleChangeSpeed;

    bool goinLeft = false;
    float currentAberration = 0;

    protected override void Move() {
        base.Move();
        if(goinLeft) {
            transform.Rotate(Vector3.up * angleChangeSpeed * Time.deltaTime);
            currentAberration += angleChangeSpeed * Time.deltaTime;
            if(currentAberration >= maxAngle) {
                goinLeft = !goinLeft;
            }
        } else {
            transform.Rotate(-Vector3.up * angleChangeSpeed * Time.deltaTime);
            currentAberration -= angleChangeSpeed * Time.deltaTime;

            if (currentAberration <= -maxAngle) {
                goinLeft = !goinLeft;
            }
        }
    }
}
