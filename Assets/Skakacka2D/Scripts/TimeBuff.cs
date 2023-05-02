using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBuff : Buff
{
    private void Start() {
        StacksChanged += OnStacksChanged;
    }

    private void OnStacksChanged() {
        Time.timeScale = GetMultiplier();
    }
}
