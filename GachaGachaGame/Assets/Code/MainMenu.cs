using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadRollMenu()
    {
        SceneManager.LoadScene("RollingScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadInventoryMenu()
    {
        SceneManager.LoadScene("Inventory");
    }

    public void QuitGame()
    {
        Debug.Log("Game has been Quit");
        Application.Quit();
    }
}
