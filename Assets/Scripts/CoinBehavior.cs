using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.GetComponentInParent<PlayerBehaviour>() != null)
        {
            PlayerBehaviour pb = other.gameObject.GetComponent<PlayerBehaviour>();

            if (pb != null)
            {
                pb.collectCoin();

                //coinCount ++;
                //UpdateCoinText();

                Destroy(this.gameObject);
            }
        }
    }

    /*void UpdateCoinText()
    {
        coinText.text = "Stars Collected: " + coinCount;
    }*/
}
