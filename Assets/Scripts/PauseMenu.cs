using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    private bool isPaused;
    public GameObject PausePanel;

    // Start is called before the first frame update
    void Start()
    {
        PausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        isPaused = true;   
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        isPaused = false;

    }
}
