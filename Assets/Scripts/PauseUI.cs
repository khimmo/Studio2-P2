using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{


    public bool paused;
    public GameObject pauseScreen;

    public void Start()
    {
        paused = false;
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pauseScreen.SetActive(true);
            paused = true;
            Time.timeScale = 0;

        }
    }

    public void Back()
    {
        pauseScreen.SetActive(false);
        paused = false;
        Time.timeScale = 1;

    }
    public void Reset()
    {

        SceneManager.LoadScene(1);

    }

    public void TitleScreen()
    {
        SceneManager.LoadScene(0);
    }
}


