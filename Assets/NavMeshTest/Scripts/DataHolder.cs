using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class DataHolder
{
    private static DataHolder instance = new DataHolder();

    public static DataHolder Instance => instance;

    private DataHolder() {

    }

    //----------------------------- ^^^ Singleton things :)
    //----------------------------- vvv Other things - implementation :)

    private Symbol playerReference;
    public Symbol Player => playerReference;
    
    private List<StaticSymbol> enemies = new List<StaticSymbol>();

    public void SetPlayerReference(Symbol playerReference) {
        this.playerReference = playerReference;
    }

    public void AddEnemy(StaticSymbol enemy) {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(StaticSymbol enemy) {
        enemies.Remove(enemy);
        if(enemies.Count == 0) {
            Time.timeScale = 0;
        }
    }
}