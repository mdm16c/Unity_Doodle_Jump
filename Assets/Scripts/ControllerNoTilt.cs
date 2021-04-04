using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerNoTilt : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float moveInput;
    public float speed = 1500f;
    private GameObject cam;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        cam = GameObject.Find("Camera");
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        if (Input.acceleration.x >= .125 || Input.acceleration.x <= -.125) {
            float horizontalMove = Input.acceleration.x * 3f  * speed;
            rb2d.velocity = new Vector2(horizontalMove, rb2d.velocity.y);
        }
        else {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        
        Debug.Log(Input.acceleration.x);
        
        
        if(cam.transform.position.y - player.transform.position.y < 1)
            cam.transform.position = new Vector3(0, player.transform.position.y + 1, -15);

        if(cam.transform.position.y - player.transform.position.y > 10)
            Destroy(player);
    }
}
