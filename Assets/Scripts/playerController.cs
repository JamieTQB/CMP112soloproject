using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody rb;
    float moveLeft;
    float moveRight;
    public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            movement = rb.transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement = -rb.transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.rotation = Quaternion.Euler(0, 0, 45).normalized;
            movement = -rb.transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.rotation = Quaternion.Euler(0, 0, -45).normalized;
            movement = rb.transform.right;
        }
        if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            rb.rotation = Quaternion.identity;
        }
        movement = movement.normalized * speed;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
        //rb.rotation = Quaternion.Euler(0, 0, 0);
    }
}
