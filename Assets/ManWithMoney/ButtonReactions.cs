using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonReactions : MonoBehaviour
{
    public void EndGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("ManWithMoneyGame");
    }
}
