﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float moveInput;
    public float speed = 1500f;
    public GameObject cam;
    private float camZ;
    private float topScore = 0.0f;
    public Text scoreText;
    private float minX, maxX;
    public GameManager manny;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Camera mainCam = cam.GetComponent<Camera>();
        maxX = mainCam.ScreenToWorldPoint(new Vector3(0, 0, cam.transform.position.z)).x;
        minX = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z)).x;
        camZ = cam.transform.position.z;
        manny = canvas.GetComponent<GameManager>();
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
            cam.transform.position = new Vector3(0, transform.position.y + 1, camZ);

        if(cam.transform.position.y - transform.position.y > 15)
            manny.isGameOver = true;

        // screen wrap
        Vector2 oldPos = transform.position;
        if (transform.position.x > maxX) {
            transform.position = new Vector2(minX, oldPos.y);
        }
        else if (transform.position.x < minX) {
            transform.position = new Vector2(maxX, oldPos.y);
        }
    }
}
