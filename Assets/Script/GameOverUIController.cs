using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    public Button mainMenuButton;
    public Button creditButton;

    private void Start()
    {
        mainMenuButton.onClick.AddListener(MainMenu);
        creditButton.onClick.AddListener(SceneCredit);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SceneCredit()
    {
        SceneManager.LoadScene("SceneCredit");
    }
}
