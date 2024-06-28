using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Controlador controlador;

    void Start()
    {
        controlador = GameObject.Find("Controlador").GetComponent<Controlador>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            controlador.FimDeJogo();
        }
    }
}