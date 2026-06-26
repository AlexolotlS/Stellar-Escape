using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject[] doors;
    [SerializeField] RoomDamageTracker roomDamageTracker;
    [SerializeField] GameObject winScreen;
    [SerializeField] bool opensDoors = true;
    [SerializeField] bool winsGame = false;
    [SerializeField] float maxButtons;
    int currButton = 1;

    public void OpenDoors() {
        foreach (GameObject door in doors) {
            door.SetActive(false);
        }
    }

    private void Win() {
        winScreen.SetActive(true);
    }

    public void CheckButton(int button) {
        if (button == currButton) {
            if (currButton >= maxButtons && roomDamageTracker.IsRoomFixed()) {
                if (opensDoors) OpenDoors();
                if (winsGame) Win();
            } else {
                currButton++;
                print("CORRECT BUTTON PRESSED");
            }         
        } else {
            print("WRONG BUTTON, SHOULD BE: " + currButton + ". GOT " + button);
            currButton = 1;
        }
    }
}
