using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol : StaticSymbol
{
    [SerializeField]
    private float timeToChangeSymbol = 5;

    protected override void Awake() {
        DataHolder.Instance.SetPlayerReference(this);
    }

    protected override void OnDestroy() {
        // nic se nebude dít, pøepisujeme jen proto, aby se pøi destroy hráèe nesnažil
        // removenout z listu enemies
    }

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

    public bool WouldEnemyWin(SymbolEnum enemy) {
        if (Symbol == SymbolEnum.Rock)
            return enemy == SymbolEnum.Paper;
        if (Symbol == SymbolEnum.Scissors)
            return enemy == SymbolEnum.Rock;
        if (Symbol == SymbolEnum.Paper) 
            return enemy == SymbolEnum.Scissors;

        return false;
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other);
        var enemy = other.GetComponentInParent<StaticSymbol>();
        if(enemy != null) {
            if (enemy.Symbol == Symbol)
                return;
            if(WouldEnemyWin(enemy.Symbol)) {
                Debug.Log("Hráè umøel... :(");
                Time.timeScale = 0;
            } else {
                Destroy(enemy.gameObject);
            }
        }
    }

}

public enum SymbolEnum
{
    Rock, Paper, Scissors
}