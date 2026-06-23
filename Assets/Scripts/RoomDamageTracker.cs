using System;
using TMPro;
using UnityEngine;

public class RoomDamageTracker : MonoBehaviour
{
    public float damagedParts;
    [SerializeField] GameObject[] doors;
    [SerializeField] TextMeshProUGUI roomText;

    public void RoomFixed() {
        roomText.color = Color.green;
        OpenDoors();
    }

    public void OpenDoors() {
        foreach (GameObject door in doors) {
            door.SetActive(false);
        }
    }
}
