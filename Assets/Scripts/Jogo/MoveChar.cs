using UnityEngine;

public class MoveChar : MonoBehaviour
{
    Rigidbody rb;
    float turnSpeed, moveSpeed;

    void Start()
    {
        turnSpeed = 10;
        moveSpeed = 25;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (vertical > 0)
        {
            rb.velocity += (transform.forward * (moveSpeed* vertical)) * Time.deltaTime;
        }

        if (vertical < 0)
        {
            rb.velocity += (transform.forward * (moveSpeed * vertical)) * Time.deltaTime;
        }

        if (horizontal > 0 || horizontal < 0)
        {
            transform.Rotate(0, (((turnSpeed * 6) * horizontal) * Time.deltaTime), 0);
        }
    }
}