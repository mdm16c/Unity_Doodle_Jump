﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPlatform : MonoBehaviour
{
    public Controller cont;
    private void Start() {
        cont = GameObject.Find("Player").GetComponent<Controller>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0) {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * (600f + cont.getExtraJump()));
            Destroy(gameObject);
        }
    }
}
