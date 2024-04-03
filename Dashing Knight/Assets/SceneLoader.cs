using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float delay = 1.0f; // Adjust the delay as needed
    private bool collided = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("next") && !collided)
        {
            collided = true;
            Invoke("LoadNextScene", delay);
        }
    }

    private void LoadNextScene()
    {
        // Load the next scene here
        SceneManager.LoadScene("Level");
    }
}
