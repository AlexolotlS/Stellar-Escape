using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardBehavior : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.GetComponentInParent<PlayerBehaviour>() != null)
        {
            PlayerBehaviour pb = other.gameObject.GetComponent<PlayerBehaviour>();

            if (pb != null)
            {
                pb.die();

                //pb.EnableRagdoll();
            }
        }
    }
}
