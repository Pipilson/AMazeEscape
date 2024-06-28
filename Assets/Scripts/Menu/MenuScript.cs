using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public InputField inputX, inputY;
    public Button playButton;
    public Buttons play;

    void Start()
    {
        Screen.SetResolution(1336, 768, true);
        inputX.ActivateInputField();
        playButton.interactable = false;
    }

    void Update()
    {
        QualitityOfLife();
        MapSizeLimit();
        EnablePlay();
    }

    private void EnablePlay()
    {
        if (inputX.text != "" && inputY.text != "")
        {
            playButton.interactable = true;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                play.Play();
            }
        }

        else
        {
            playButton.interactable = false;
        }
    }

    private void QualitityOfLife()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inputX.isFocused)
            {
                inputY.ActivateInputField();
            }

            if (inputY.isFocused)
            {
                inputX.ActivateInputField();
            }
        }
    }

    private void MapSizeLimit()
    {
        if (inputX.text != "")
        {
            if (int.Parse(inputX.text) > 200)
            {
                inputX.text = "200";
            }

            if (int.Parse(inputX.text) < 10 && !inputX.isFocused)
            {
                inputX.text = "10";
            }
        }

        if (inputY.text != "")
        {
            if (int.Parse(inputY.text) > 200)
            {
                inputY.text = "200";
            }

            if (int.Parse(inputY.text) < 10 && !inputY.isFocused)
            {
                inputY.text = "10";
            }
        }
    }
}