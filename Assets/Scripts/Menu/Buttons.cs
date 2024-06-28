using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public MenuScript inputSize;
    public MapSize map;

    public void Play()
    {
        if (inputSize.inputX.text != "" && inputSize.inputY.text != "")
        {
            map.mazeX = int.Parse(inputSize.inputX.text);
            map.mazeY = int.Parse(inputSize.inputY.text);
            SceneManager.LoadScene("Jogo");
        }
    }

    public void Sortear()
    {
        int rndX = Random.Range(10, 201);
        int rndY = Random.Range(10, 201);

        inputSize.inputX.text = rndX.ToString();
        inputSize.inputY.text = rndY.ToString();
    }

    public void Quit()
    {
        Application.Quit();
    }
}