using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float boostMultiplier;
    public bool boosting;
    private AudioSource source;
    public AudioClip boostSFX;
    float moveForwards;
    float moveSideways;
    
    Vector3 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        source = GetComponent<AudioSource>();
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        moveForwards = movementVector.y;
        moveSideways = movementVector.x;
    }
    void OnBoost()
    {
        StartCoroutine(Boost());
        boosting = true;
        source.PlayOneShot(boostSFX, 1.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement = new Vector3(moveSideways, 0.0f, moveForwards);

        //Vector3 movement = Vector3.zero;
        if (moveForwards == 0)
        {
            
        }
        if (moveSideways < 0)
        {
            rb.rotation = Quaternion.Euler(0, 0, 45).normalized;
            
        }
        
        if (moveSideways > 0)
        {
            rb.rotation = Quaternion.Euler(0, 0, -45).normalized;
           
        }
      
        if (moveSideways == 0)
        {
            rb.rotation = Quaternion.identity;
            rb.linearVelocity = Vector3.zero;
        }
        if (boosting)
        {
            movement = movement.normalized * speed * boostMultiplier;
            rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
        }
        else
        {
            movement = movement.normalized * speed;
            rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
        }
        rb.AddForce(movement * speed);

    }

    
    IEnumerator Boost()
    {
        yield return new WaitForSeconds(1f);
        boosting = false;
    }
}
