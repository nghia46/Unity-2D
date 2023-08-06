using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnventManager : MonoBehaviour
{
    public static EnventManager Instance;
    public event Action<int> OpenDoorEvent;
    public event Action CoinCollectEvent;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartDoorEvent(int id)
    {
        if (OpenDoorEvent != null)
        {
            OpenDoorEvent.Invoke(id);
        }
        else
        {
            Debug.Log("No Event!");
        }
    }
    public void StartCoinCollectEvent()
    {
        if (CoinCollectEvent != null)
        {
            CoinCollectEvent.Invoke();
        }
        else Debug.Log("No Event! in coinEvent");
    }
}
