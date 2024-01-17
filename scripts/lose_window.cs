using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lose_window : MonoBehaviour
{
    [SerializeField] GameObject loseWindow;
    public void showLoseWindow()
    {
        loseWindow.SetActive(true);
    }

    public void retryBttn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void menuBttn()
    {
        SceneManager.LoadScene(0);
    }
}
