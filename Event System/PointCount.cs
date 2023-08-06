using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointCount : MonoBehaviour
{
    public int countCoin;
    bool isCoinCollected = false;
    public TextMeshProUGUI point;
    void Start()
    {
        EnventManager.Instance.CoinCollectEvent += UpdateScorce;
    }
    void Update()
    {
        if(isCoinCollected)
        {
            point.text = countCoin.ToString();
            isCoinCollected = false;
        }
    }
    void UpdateScorce()
    {
        countCoin+= 1; 
        isCoinCollected = true; 
    }
    private void OnDisable() {
        EnventManager.Instance.CoinCollectEvent -= UpdateScorce;
    }
}
