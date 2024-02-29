using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject blade;

    private void Awake()
    {
        pauseMenu.SetActive(false);

    }

    public void PauseSystem()
    {
        if(pauseMenu.activeSelf == true)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            blade.SetActive(true);
        }

        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            blade.SetActive(false);
        }
    }

    public void Restart()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void VolumeUp()
    {

    }

    public void VolumeDown()
    {

    }
}
