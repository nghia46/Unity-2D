using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public int doorID;
    bool open = false;
    void Start()
    {
        EnventManager.Instance.OpenDoorEvent += OpenDoorEv;
    }
    void Update()
    {
        if (open)
        {
            Destroy(this.gameObject);
        }
    }
    void OpenDoorEv(int triggerId)
    {
        if (triggerId.Equals(doorID))
        {
            open = true;
        }
    }
    private void OnDisable()
    {
        EnventManager.Instance.OpenDoorEvent -= OpenDoorEv;
    }
}
