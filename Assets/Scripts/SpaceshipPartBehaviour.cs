using Unity.VisualScripting;
using UnityEngine;

public class SpaceshipPartBehaviour : MonoBehaviour
{
    [SerializeField] PartManager partManager;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") || other.GetComponentInParent<PlayerBehaviour>() != null)
        {
            PlayerBehaviour pb = other.gameObject.GetComponent<PlayerBehaviour>();

            if (pb != null)
            {
                partManager.CollectPart();
                Destroy(this.gameObject);
                print("Collected a Spaceship Part!");
            }
        }
    }
}
