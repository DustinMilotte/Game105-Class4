using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //public float speed = 10f;
    public Text scoreText;
    public AudioClip pickupSound;

    private string myString;
    private GameManager gameManager;
    private int count = 0;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        // print("Hello, World!");
        //rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        /*  float moveHorizontal = Input.GetAxis("Horizontal");
          float moveVertical = Input.GetAxis("Vertical");

          Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
          rb.AddForce(movement * speed);
          if(Input.GetAxis("Jump") > 0)
          {
              rb.AddForce(Vector3.up, ForceMode.VelocityChange);
          }
          */
        // rb.velocity = movement * speed;
        //rb.MovePosition(transform.position + (movement * Time.deltaTime * speed)); 
        //transform.Translate(movement * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            scoreText.text = "Score: " + count.ToString();
            AudioSource.PlayClipAtPoint(pickupSound, other.transform.position );
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            gameManager.GoalReached();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            gameManager.GameOver();
        }
    }
}