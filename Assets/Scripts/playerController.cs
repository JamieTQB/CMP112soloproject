using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float boostSpeed;
    bool boosting;
    float moveForwards;
    float moveSideways;
    Vector3 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        moveForwards = movementVector.y;
        moveSideways = movementVector.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement = new Vector3(moveSideways, 0.0f, moveForwards);

        rb.AddForce(movement * speed);
        //Vector3 movement = Vector3.zero;
        if (moveForwards == 0)
        {
            rb.linearVelocity = Vector3.zero;
        }
        if (moveSideways < 0)
        {
            rb.rotation = Quaternion.Euler(0, 0, 45).normalized;
            //movement = -rb.transform.right;
        }
        
        if (moveSideways > 0)
        {
            rb.rotation = Quaternion.Euler(0, 0, -45).normalized;
            //movement = rb.transform.right;
        }
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Boost());
            boosting = true;
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }*/
        if (moveSideways == 0)
        {
            rb.rotation = Quaternion.identity;
            rb.linearVelocity = Vector3.zero;
        }/*
        if (boosting)
        {
            movement = movement.normalized * speed * boostSpeed;
            rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
        }
        else
        {
            movement = movement.normalized * speed;
            rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
        }*/


    }
    
    IEnumerator Boost()
    {
        yield return new WaitForSeconds(1f);
        boosting = false;
    }
}
