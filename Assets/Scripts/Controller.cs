using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float moveInput;
    public float speed = 1500f;
    public GameObject cam;
    private float topScore = 0.0f;
    public Text scoreText;
    // private float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        // Camera mainCam = cam.GetComponent<Camera>();
        // Vector2 tempMin = mainCam.ViewportToWorldPoint(new Vector2(0, 0));
        // Vector2 tempMax = mainCam.ViewportToWorldPoint(new Vector2(Screen.width, Screen.height));
        // minX = tempMin.x;
        // maxX = tempMax.x;
        // Debug.Log(minX);
        // Debug.Log(maxX);
    }

    void FixedUpdate()
    {
        // tilt controls
        if (Input.acceleration.x >= .125 || Input.acceleration.x <= -.125) {
            if (Input.acceleration.x < 0) {
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
            else {
                this.GetComponent<SpriteRenderer>().flipX = true;
            }
            float horizontalMove = Input.acceleration.x * 3f  * speed;
            rb2d.velocity = new Vector2(horizontalMove, rb2d.velocity.y);
        }
        else {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        // keyboard controls for my sanity (for debug not final product)
        moveInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveInput * 10, rb2d.velocity.y);
        if (moveInput < 0) {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (moveInput > 0) {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        
        // score text
        if (rb2d.velocity.y > 0 && transform.position.y > topScore) {
            topScore = transform.position.y;
        }
        scoreText.text = "Score: " + Mathf.Round(topScore).ToString();
        
        // camera movement
        if(cam.transform.position.y - transform.position.y < 1)
            cam.transform.position = new Vector3(0, transform.position.y + 1, -15);

        if(cam.transform.position.y - transform.position.y > 10)
            Destroy(gameObject);

        // screen wrap
        // Vector2 oldPos = transform.position;
        // if (transform.position.x > Screen.width) {
        //     transform.position = new Vector2(0, oldPos.y);
        // }
        // else if (transform.position.x < 0) {
        //     transform.position = new Vector3(Screen.width, oldPos.y);
        // }
    }
}
