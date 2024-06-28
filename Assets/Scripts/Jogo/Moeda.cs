using UnityEngine;

public class Moeda : MonoBehaviour
{
    public Controlador controlador;

    void Start()
    {
        controlador = GameObject.Find("Controlador").GetComponent<Controlador>();
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0.5f, 1), 100 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            controlador.PontoUp();
            Destroy(gameObject);
        }
    }
}