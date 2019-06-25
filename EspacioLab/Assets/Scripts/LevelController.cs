using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    [SerializeField] int delay = 2;

  public void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }


    public void LoadMainGame()
    {
        SceneManager.LoadScene("spaceLab");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {


        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Game Over");

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
