using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public int triggerID;
    private void OnTriggerEnter2D(Collider2D other) {
        EnventManager.Instance.StartDoorEvent(triggerID);
    }
}
