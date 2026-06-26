using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] ButtonManager buttonManager;
    [SerializeField] int buttonNumber;
    [SerializeField] Material buttonColorMat;
    [SerializeField] GameObject buttonObject;
    bool isLit = false;
    bool activated = false;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && !activated && isLit) {
            activated = true;
            buttonManager.CheckButton(buttonNumber);
        }
    }

    private void OnTriggerExit(Collider other) {
        activated = false;
    }

    public void LightUp() {
        buttonObject.GetComponent<Renderer>().material = buttonColorMat;
        isLit = true;
    }
}
