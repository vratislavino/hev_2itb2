using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointDisplay : MonoBehaviour
{
    [SerializeField]
    TMP_Text pointText;

    [SerializeField]
    CoinCollector coinCollector;

    // Start is called before the first frame update
    void Start()
    {
        coinCollector.PointsChanged += OnPointsChanged;
    }

    private void OnPointsChanged(int points)
    {
        pointText.text = points.ToString();
    }
}
