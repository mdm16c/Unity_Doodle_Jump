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
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    private GameObject myPlat;
    private GameObject myEnemy;
    private GameObject myPowerUp;

    public void createStartingPlats() {
        myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(player.transform.position.x, player.transform.position.y - 1), Quaternion.identity);
        myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (5 + Random.Range(0.5f, 0.8f))), Quaternion.identity);
        myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (7 + Random.Range(0.5f, 0.8f))), Quaternion.identity);
        myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (10 + Random.Range(0.5f, 0.8f))), Quaternion.identity);
        myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (13 + Random.Range(0.5f, 0.8f))), Quaternion.identity);
        myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (18 + Random.Range(0.5f, 0.8f))), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform") {
            if (Random.Range(1, 15) == 1) {
                myEnemy = (GameObject)Instantiate(enemyPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (14 + Random.Range(0.5f, 0.8f))), Quaternion.identity);
                myEnemy.SetActive(true);
            }
            if (Random.Range(1, 15) == 1) {
                myPowerUp = (GameObject)Instantiate(powerUpPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (14 + Random.Range(0.5f, 0.8f))), Quaternion.identity);
                myPowerUp.SetActive(true);
            }

            if (Random.Range(1, 10) == 1) {
                myPlat = (GameObject)Instantiate(springPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (14 + Random.Range(0.5f, 0.8f))), Quaternion.identity);
            }
            else if (Random.Range(1, 10) == 1) {
                myPlat = (GameObject)Instantiate(breakPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (14 + Random.Range(0.5f, 0.8f))), Quaternion.identity);
            }
            else {
                myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (14 + Random.Range(0.5f, 0.8f))), Quaternion.identity);
            }
        }
        Destroy(collision.gameObject);
    }
}
