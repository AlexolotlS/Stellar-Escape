using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] ButtonManager buttonManager;
    [SerializeField] int buttonNumber;
    bool activated = false;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && !activated) {
            activated = true;
            buttonManager.CheckButton(buttonNumber);
        }
    }

    private void OnTriggerExit(Collider other) {
        activated = false;
    }
}
