using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSettings : MonoBehaviour
{
    [SerializeField] private GameObject sound;
    // Start is called before the first frame update
    void Start()
    {
        sound.SetActive(false);
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Option()
    {
        sound.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Back()
    {
        sound.SetActive(false);
    }
}
