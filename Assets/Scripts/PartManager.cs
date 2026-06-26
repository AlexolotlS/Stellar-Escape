using UnityEngine;

public class PartManager : MonoBehaviour
{
    [SerializeField] GameObject portal;
    [SerializeField] int partsNeeded = 5;
    int partsCollected = 0;

    public void CollectPart() {
        partsCollected++;
        if (partsCollected >= partsNeeded) {
            ActivatePortal();
        }
    }

    void ActivatePortal() {
        portal.SetActive(true);
    }
}
