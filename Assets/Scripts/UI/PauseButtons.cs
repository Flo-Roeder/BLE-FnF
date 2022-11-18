using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour
{
    private bool canPush;
    private bool gameIsPaused;
    [SerializeField] GameObject pausePanel;
    [SerializeField] PlayerController playerController;

    private void Start()
    {
        canPush = true;
        pausePanel.SetActive(false);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void PauseGame(InputAction.CallbackContext context)
    {
        if (context.started
            && canPush)
        {
            canPush = false;
            StartCoroutine(ResetButton());
            if (!gameIsPaused)
            {
            gameIsPaused = true;
            playerController.gameIsPaused = true;
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            }
        }
    }

    public void ResumeGame()
    {
        gameIsPaused = false;
        playerController.gameIsPaused = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }


    private IEnumerator ResetButton()
    {
        yield return null;
        canPush = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

}
