using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreLivesFool : NormalFool
{
    [SerializeField]
    private int maxLives;

    protected int currentLives;

    protected override void Start() {
        base.Start();
        currentLives = maxLives;
    }

    protected override void ReactToHit() {
        MinusLife();
        if (currentLives == 0) {
            currentLives = maxLives;
            base.ReactToHit();
        }
    }

    protected virtual void MinusLife() {
        currentLives--;
    }
}

