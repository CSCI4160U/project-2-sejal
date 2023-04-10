using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void NewGame()
    {
        Debug.Log("Creating New Game");
        SceneManager.LoadScene("MainLevel");
    }

    public void Credits()
    {
        Debug.Log("Navigating to Credits");
        SceneManager.LoadScene("CreditsScene");
    }
}