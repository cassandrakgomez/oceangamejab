using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
        public void StartGame()
        {
            Debug.Log("Play Button Working!");
            SceneManager.LoadScene("Game");
        }
        public void QuitGame()
        {
            Debug.Log("Quit Button Working!");
            Application.Quit();
        }
        public void Settings()
        {
            Debug.Log("Settings Button Working!");
            SceneManager.LoadScene("Settings");
        }

        public void MainMenu()
        {
            Debug.Log("Main Menu Button Working!");
            SceneManager.LoadScene("MainMenu");
        }
    }
