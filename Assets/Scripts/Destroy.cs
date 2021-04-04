using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab;
    public GameObject springPrefab;
    public GameObject breakPrefab;
    private GameObject myPlat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Random.Range(1, 10) == 1) {
            myPlat = (GameObject)Instantiate(springPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (14 + Random.Range(0.5f, 0.8f))), Quaternion.identity);
        }
        else if (Random.Range(1, 10) == 1) {
            myPlat = (GameObject)Instantiate(breakPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (14 + Random.Range(0.5f, 0.8f))), Quaternion.identity);
        }
        else {
            myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (14 + Random.Range(0.5f, 0.8f))), Quaternion.identity);
        }
        Destroy(collision.gameObject);
    }
}
