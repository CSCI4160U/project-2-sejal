using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    public void BacktoMenu()
    {
        Debug.Log("Navigating to MainMenu");
        SceneManager.LoadScene("MainMenu");
    }
}