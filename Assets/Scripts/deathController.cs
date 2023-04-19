using UnityEngine;
using UnityEngine.SceneManagement;

public class deathController : MonoBehaviour
{
    public void Return()
    {
        Debug.Log("Loading Main Menu");
        SceneManager.LoadScene("MainMenu");
    }
}