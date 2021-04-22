using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPlatform : MonoBehaviour
{
    public Controller cont;
    public Destroy ds;
    private void Start() {
        GameObject player = GameObject.Find("Player");
        cont = player.GetComponent<Controller>();
        ds = player.GetComponentInChildren<Destroy>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0) {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * (600f + cont.getExtraJump()));
            ds.createSinglePlatform(gameObject.transform.position.y);
            Destroy(gameObject);
        }
    }
}
