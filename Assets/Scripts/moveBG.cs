using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBG : MonoBehaviour
{
    public Transform centerBackground;
    public Transform topBackground;
    private float delta;
    private bool centerMove = true;
    private void Start() {
        delta = topBackground.position.y - centerBackground.position.y;
    }
    void Update() {
        if (centerMove) {
            if (transform.position.y >= topBackground.position.y) {
                centerBackground.position = new Vector2(centerBackground.position.x, topBackground.position.y + delta);
                centerMove = false;
            }
        }
        else {
            if (transform.position.y >= centerBackground.position.y) {
                topBackground.position = new Vector2(topBackground.position.x, centerBackground.position.y + delta);
                centerMove = true;
            }
        }
        
    }
}
