using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinCollector : MonoBehaviour
{
    public event Action<int> PointsChanged;

    int points = 0;

    [SerializeField]
    private GameObject DeathScreen;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            points++;

            if (PointsChanged != null)
                PointsChanged(points);

            Destroy(collision.gameObject);
        } else
        {
            DeathScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }
}
