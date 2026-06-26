using System;
using TMPro;
using UnityEngine;

public class RoomDamageTracker : MonoBehaviour
{
    public float damagedParts;
    [SerializeField] GameObject[] doors;
    [SerializeField] ButtonBehaviour[] buttons;
    [SerializeField] TextMeshProUGUI roomText;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] bool activateGravity;
    bool roomFixed = false;

    public void RoomFixed() {
        roomFixed = true;
        roomText.color = Color.green;
        if (doors.Length > 0) {
            foreach (GameObject door in doors) {
                OpenDoors();
            }
        }
        if (activateGravity) {
            ActivateGravity();
        }
        if (buttons.Length > 0) {
            foreach (ButtonBehaviour button in buttons) {
                button.LightUp();
            }
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

    public bool IsRoomFixed() {
        return roomFixed;
    }
}
