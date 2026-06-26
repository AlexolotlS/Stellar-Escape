using UnityEngine;

public class DamagedObject : MonoBehaviour, IInteractable
{
    [SerializeField] RoomDamageTracker RDT;
    [SerializeField] GameObject[] particles;
    bool isFixed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInteract() {
        if (!isFixed) {
            foreach (GameObject particle in particles) {
                particle.SetActive(false);
            }
            isFixed = true;
            RDT.damagedParts--;

            if (RDT.damagedParts <= 0) {
                RDT.RoomFixed();
            }
        }
    }
}
