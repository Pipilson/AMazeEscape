using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text highScoreTxt, novoScore;
    public InputField nome;
    public Button save;
    public MontarLabirinto montar;
    public Timer timer;
    public Controlador controlador;
    string nomeHS, secHS, minHS, hourHS, pontoHS;
    void Start()
    {
        nome.gameObject.SetActive(false);
        save.gameObject.SetActive(false);
        save.interactable = false;
        novoScore.text = "";
        highScoreTxt.text = "";

        nomeHS = PlayerPrefs.GetString("Nome", "Ninguém");
        secHS = PlayerPrefs.GetInt("Segundos", 59).ToString("00");
        minHS = PlayerPrefs.GetInt("Minutos", 59).ToString("00");
        hourHS = PlayerPrefs.GetInt("Horas", 99).ToString("00");
        pontoHS = PlayerPrefs.GetInt("Pontos", 0).ToString();
    }

    void Update()
    {
        if (montar.ironman && Time.timeScale == 1)
        {
            highScoreTxt.text = "HighScore\n" + nomeHS + "\n" + hourHS + ":" + minHS + ":" + secHS + "\n" + pontoHS + " Pontos";
        }

        if (montar.ironman && Time.timeScale == 0)
        {
            if (timer.hour < int.Parse(hourHS))
            {
                NewRecord();
            }        

            else if (timer.hour == int.Parse(hourHS))
            {
                if (timer.min < int.Parse(minHS))
                {
                    NewRecord();
                }

                else if (timer.min == int.Parse(minHS))
                {
                    if (timer.sec < int.Parse(secHS))
                    {
                        NewRecord();
                    }

                    else if (timer.sec == int.Parse(secHS))
                    {
                        if (controlador.pontos >= int.Parse(pontoHS))
                        {
                            NewRecord();
                        }
                    }
                }
            }
        }
    }

    void NewRecord()
    {
        novoScore.text = "Novo HighScore!\nInsira seu nome:";
        nome.gameObject.SetActive(true);
        save.gameObject.SetActive(true);

        if (nome.text != "")
        {
            save.interactable = true;
        }

        else
        {
            save.interactable = false;
        }
    }

    public void Save()
    {
        PlayerPrefs.SetString("Nome", nome.text);
        PlayerPrefs.SetInt("Segundos", timer.sec);
        PlayerPrefs.SetInt("Minutos", timer.min);
        PlayerPrefs.SetInt("Horas", timer.hour);
        PlayerPrefs.SetInt("Pontos", controlador.pontos);

        highScoreTxt.text = "HighScore\n" + nome.text + "\n" + timer.hour.ToString("00") + ":" + timer.min.ToString("00") + ":" + timer.sec.ToString("00") + "\n" + controlador.pontos + " Pontos";
    }
}