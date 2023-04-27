using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : MonoBehaviour
{
    protected float duration;
    protected float baseMutiplier;
    protected BuffType buffType;

    protected int stacks = 0;

    protected float remainingTime;

    public float GetMultiplier() {
        return Mathf.Pow(baseMutiplier, stacks);
    }

    public void Collect(float duration, BuffType buffType, float baseMult) {
        this.duration = duration;
        this.baseMutiplier = baseMult;
        this.buffType = buffType;

        stacks++;
        remainingTime = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if(stacks > 0) {
            remainingTime -= Time.deltaTime;
            if(remainingTime <= 0) {
                stacks--;
                if(stacks > 0) {
                    remainingTime = duration;
                } else {
                    Destroy(this);
                }
            }
        }
    }
}

public enum BuffType
{
    Jump, Speed, Time
}