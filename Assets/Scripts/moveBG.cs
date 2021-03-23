using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBG : MonoBehaviour
{
    public Transform centerBackground;
    public float delta = 10.0f;
    void Update()
    {
        if (transform.position.y >= centerBackground.position.y + delta) {
            centerBackground.position = new Vector2(centerBackground.position.x, transform.position.y + delta);
        }
        else if (transform.position.y <= centerBackground.position.y - delta) {
            centerBackground.position = new Vector2(centerBackground.position.x, transform.position.y - delta);
        }
    }
}
