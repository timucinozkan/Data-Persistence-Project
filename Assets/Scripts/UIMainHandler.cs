using UnityEngine;

public class UIMainHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void returnToMenu()
    {
        // Load the menu scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
