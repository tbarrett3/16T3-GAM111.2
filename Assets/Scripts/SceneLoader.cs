using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName;

    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "SplashScreen")
        {
            StartCoroutine (SplashCount());
        }
    }

        IEnumerator SplashCount()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("MainMenu");
            print("splash count");
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LevelSelect()
    {

    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
}
