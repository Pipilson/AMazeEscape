using UnityEngine;
using UnityEngine.UI;

public class Controlador : MonoBehaviour
{
    public Button again, quit;
    public Text gameOver, pontosTxt;
    public int pontos;

    void Start()
    {
        again.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        gameOver.text = "";
    }

    void Update()
    {
        pontosTxt.text = "Pontos- " + pontos;
    }

    public void PontoUp()
    {
        pontos++;
    }

    public void FimDeJogo()
    {
        gameOver.text = "FIM DE JOGO";
        again.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}