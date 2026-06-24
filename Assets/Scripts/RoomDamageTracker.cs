using System;
using TMPro;
using UnityEngine;

public class RoomDamageTracker : MonoBehaviour
{
    public float damagedParts;
    [SerializeField] GameObject[] doors;
    [SerializeField] TextMeshProUGUI roomText;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] bool activateGravity;

    public void RoomFixed() {
        roomText.color = Color.green;
        OpenDoors();
        if (activateGravity) {
            ActivateGravity();
        }
    }

    public void OpenDoors() {
        foreach (GameObject door in doors) {
            door.SetActive(false);
        }
    }

    void ActivateGravity() {
        if (playerMovement != null) {
            playerMovement.jumpHeight = 2;
        }
    }
}
