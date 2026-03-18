using System;
using UnityEngine;

public class RewardController : MonoBehaviour
{
    GameObject door;
    DoorController doorCon;

    void Start()
    {
        door = this.gameObject;
        doorCon = GetComponent<DoorController>();


    }
}
