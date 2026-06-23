using UnityEngine;

public class InteractionBoxBehaviour : MonoBehaviour
{
    IInteractable currInteractable;

    public void TryInteract() {
        currInteractable?.OnInteract();
    }

    private void OnTriggerEnter(Collider other) {
        print(other.name);
        if (other.TryGetComponent(out IInteractable interactable)) {
            print("OBJECT IS INTERACTBLE: " + other.name);
            currInteractable = interactable;
        }
    }

    private void OnTriggerExit(Collider other) {
        currInteractable = null;
    }
}
