using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalBehavior : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.GetComponentInParent<PlayerBehaviour>() != null)
        {
            PlayerBehaviour pb = other.gameObject.GetComponent<PlayerBehaviour>();

            if (pb != null)
            {
                SceneManager.LoadScene(sceneName);
                print("Switched Scene to: " + sceneName);
            }
        }
    }
}
