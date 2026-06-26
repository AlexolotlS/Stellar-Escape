using TMPro;
using UnityEngine;

public class PartManager : MonoBehaviour
{
    [SerializeField] GameObject portal;
    [SerializeField] TextMeshProUGUI partCollectedText;
    [SerializeField] TextMeshProUGUI portalText;
    [SerializeField] int partsNeeded = 5;
    int partsCollected = 0;

    public void CollectPart() {
        partsCollected++;
        if (partsCollected >= partsNeeded) {
            ActivatePortal();
        }
        partCollectedText.text = "Parts Collected: " + partsCollected;
    }

    void ActivatePortal() {
        portal.SetActive(true);
        portalText.gameObject.SetActive(true);
    }
}
