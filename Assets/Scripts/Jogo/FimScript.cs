using UnityEngine;
using UnityEngine.SceneManagement;

public class FimScript : MonoBehaviour
{
    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}