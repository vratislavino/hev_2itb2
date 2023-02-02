using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol : StaticSymbol
{
    [SerializeField]
    private float timeToChangeSymbol = 5;

    protected override void Start() {
        base.Start();

        StartCoroutine(ChangeSymbolRoutine());
    }

    IEnumerator ChangeSymbolRoutine() {
        while(true) {
            yield return new WaitForSeconds(timeToChangeSymbol);
            ChangeSymbol(GenerateSymbol());
        }
    }

}

public enum SymbolEnum
{
    Rock, Paper, Scissors
}