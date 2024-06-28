using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Controlador controlador;
    public Text tempo, over;
    public Button again, quit;
    string secTxt, minTxt, hourTxt;
    float timer;
    public int sec, min, hour;

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            sec++;
            timer = 0;

            if (sec > 59)
            {
                sec = 0;
                min++;

                if (min > 59)
                {
                    min = 0;
                    hour++;

                    if (hour == 99 && min == 59 && sec == 59)
                    {
                        hourTxt = "10";
                        minTxt = "00";
                        secTxt = "00";
                        tempo.text = "Tempo- " + hourTxt + ":" + minTxt + ":" + secTxt;
                        over.text = "FIM DE JOGO";
                        controlador.FimDeJogo();
                    }
                }
            }
        }

        hourTxt = hour.ToString("00");
        minTxt = min.ToString("00");
        secTxt = sec.ToString("00");
        tempo.text = "Tempo- " + hourTxt + ":" + minTxt + ":" + secTxt;
    }
}