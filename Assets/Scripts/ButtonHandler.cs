using System;
using UnityEngine;
using UnityEngine.UI; // Required for working with UI elements
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    // Reference to the button (set this in the Inspector)
    [SerializeField]
    GameObject LevelUpPanel;
    [SerializeField]
    Button startButton;
    [SerializeField]
    Button exitButton;
    [SerializeField]
    Button unPauseGame;
    [SerializeField]
    Button pauseGame;
    [SerializeField]
    GameObject infoPanel;
    [SerializeField]
    Button infoButton;
    [SerializeField]
    Button closeButton;


    void Start()
    {
        // Ensure the button is assigned
        if (startButton != null)
        {
            // Add a listener to call the ButtonClicked method when the button is clicked
            startButton.onClick.AddListener(StartButtonClicked);
        }
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitButtonClicked);
        }
        if (unPauseGame != null)
        {
            unPauseGame.onClick.AddListener(UnPauseButtonClicked);
        }
        if (pauseGame != null)
        {
            pauseGame.onClick.AddListener(PauseButtonClicked);
        }
        if (infoButton != null)
        {
            infoButton.onClick.AddListener(InfoButtonClicked);
        }
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(CloseButtonClicked);
        }
    }

    void ExitButtonClicked()
    {
        Application.Quit();
    }

    // Method that is triggered when the button is clicked
    void StartButtonClicked()
    {
        SceneManager.LoadScene("Gameplay");
        
    }
    void UnPauseButtonClicked()
    {
        Time.timeScale = 1;
        LevelUpPanel.SetActive(false);
    }
    void PauseButtonClicked()
    {
        Time.timeScale = 0;
        LevelUpPanel.SetActive(true);
    }
    void InfoButtonClicked()
    {
        infoPanel.SetActive(true);
    }
    void CloseButtonClicked()
    {
        infoPanel.SetActive(false);
    }
}