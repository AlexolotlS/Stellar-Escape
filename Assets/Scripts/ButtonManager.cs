using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject[] doors;
    [SerializeField] float maxButtons;
    int currButton = 1;

    public void OpenDoors() {
        foreach (GameObject door in doors) {
            door.SetActive(false);
        }
    }

    public void CheckButton(int button) {
        if (button == currButton) {
            if (currButton >= maxButtons) {
                OpenDoors();
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
