using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public string tagToDestroy;
    public int damage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tagToDestroy)
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
