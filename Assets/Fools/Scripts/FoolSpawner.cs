using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoolSpawner : MonoBehaviour
{
    private static FoolSpawner instance;

    public static FoolSpawner Instance => instance;


    [SerializeField]
    private float TimeToSpawnNext;

    [SerializeField]
    List<SpawnData> spawnData = new List<SpawnData>();

    List<Fool> fools = new List<Fool>();

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomFool", 0, TimeToSpawnNext);
    }

    public void StopSpawner() {
        CancelInvoke("SpawnRandomFool");
    }

    private void SpawnRandomFool() {
        float rnd = UnityEngine.Random.Range(0, 100);
        float sumPerc = 0;
        for(int i = 0; i < spawnData.Count; i++) {
            if(rnd <= spawnData[i].Probability + sumPerc) {
                SpawnActualFool(spawnData[i].Prefab);
                break;
            } else {
                sumPerc += spawnData[i].Probability;
            }
        }
    }

    private void SpawnActualFool(Fool prefab) {
        fools.Add(Instantiate(prefab, transform));
    }
}

[Serializable]
class SpawnData
{
    public Fool Prefab;
    public float Probability;
}