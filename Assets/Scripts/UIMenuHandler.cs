using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIMenuHandler : MonoBehaviour
{
    public TMP_InputField iField;
    public TMP_Text welcomeMessage;
    private string playerName;

    private void Start()
    {
        if (GameManager.Instance == null || GameManager.Instance.playerName == "")
        {
            playerName = "Player";
        }
        else
        {
            playerName = GameManager.Instance.playerName;
            iField.text = playerName;
        }
        UpdateWelcomeMessage();
        iField.onValueChanged.AddListener(SetPlayerName);
    }

    // This method is called when the "Start Game" button is clicked
    public void StartGame()
    {
        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Player";
            GameManager.Instance.playerName = playerName;
        }
        SceneManager.LoadScene("main");
    }

    // This method is called when the input field value changes
    public void SetPlayerName(string newName)
    {
        playerName = newName.Trim();
        GameManager.Instance.playerName = playerName;
        UpdateWelcomeMessage();
    }

    private void UpdateWelcomeMessage()
    {
        if (string.IsNullOrEmpty(GameManager.Instance.playerName))
        {
            welcomeMessage.text = "Welcome Player!";
        }
        else
        {
            welcomeMessage.text = $"Welcome {playerName}!";
        }
    }

    // This method is called when the "Quit Game" button is clicked
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
