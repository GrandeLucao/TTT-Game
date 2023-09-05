using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject gameOverObj;
    public static GameController instance;
    public GameObject medKit;

    void Awake()
    {
        instance=this;

    }

    public void GameOver()
    {
        gameOverObj.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(2);
    }
    
    IEnumerator healthUp()
    {
        medKit.SetActive(true);
        yield return new WaitForSeconds(3f);
        medKit.SetActive(false);
    }
}
