using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (index == 1)
        {
            SceneManager.LoadScene(index + 1);
        }
        else if (index == 2)
        {
            SceneManager.LoadScene(index - 1);
        }

    }

    public void InMenu()
    {
        SceneManager.LoadScene(0);
    }
}
