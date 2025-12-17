using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

//this script is mainly for in-game controls, moving and boosting
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
    gameStateClass gamestate;
    
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
        //coroutine is used to make sure there is time between first press, speed change, then return to normal speed so no spamming boost for stacked speed boosts
        StartCoroutine(Boost());
        boosting = true;
        source.PlayOneShot(boostSFX, 1.0f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        movement = new Vector3(moveSideways, 0.0f, moveForwards);
        //the two sideways ifs for the tilt of the player model
        if (moveSideways < 0)
        {
            rb.rotation = Quaternion.Euler(0, 0, 45).normalized;
        }
        
        if (moveSideways > 0)
        {
            rb.rotation = Quaternion.Euler(0, 0, -45).normalized;
        }
        //resets the tilt if not going left or right
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

    //waits a moment before flipping the boost bool back to false to make sure boost doesn't stack for too high speed
    IEnumerator Boost()
    {
        yield return new WaitForSeconds(1f);
        boosting = false;
    }
}
