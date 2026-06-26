using Unity.VisualScripting;
using UnityEngine;

public class SpaceshipPartBehaviour : MonoBehaviour
{
    [SerializeField] PartManager partManager;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") || other.GetComponentInParent<PlayerBehaviour>() != null) {
            partManager.CollectPart();
            Destroy(this.gameObject);
        }
    }
}
