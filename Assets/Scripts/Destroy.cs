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
    public GameObject revivePlatformPrefab;
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    private GameObject myPlat;
    private GameObject myEnemy;
    private GameObject myPowerUp;
    public GameObject cam;
    private float screenHeight;
    private float screenWidth;
    private void Start() {
        Camera mainCam = cam.GetComponent<Camera>();
        float maxY = mainCam.ScreenToWorldPoint(new Vector3(0, 0, cam.transform.position.z)).y;
        float minY = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z)).y;
        float maxX = mainCam.ScreenToWorldPoint(new Vector3(0, 0, cam.transform.position.z)).x;
        float minX = mainCam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z)).x;
        screenHeight = maxY - minY - .1f;
        screenWidth = (maxX - minX - 3.0f)/2;
    }

    public void createStartingPlats() {
        myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(player.transform.position.x, player.transform.position.y - 1), Quaternion.identity);
        myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-screenWidth, screenWidth), player.transform.position.y + (5 + Random.Range(0.5f, 0.8f))), Quaternion.identity);
        myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-screenWidth, screenWidth), player.transform.position.y + (7 + Random.Range(0.5f, 0.8f))), Quaternion.identity);
        myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-screenWidth, screenWidth), player.transform.position.y + (10 + Random.Range(0.5f, 0.8f))), Quaternion.identity);
        myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-screenWidth, screenWidth), player.transform.position.y + (13 + Random.Range(0.5f, 0.8f))), Quaternion.identity);
        myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-screenWidth, screenWidth), player.transform.position.y + (18 + Random.Range(0.5f, 0.8f))), Quaternion.identity);
    }

    public void createRevivePlatform() {
        myPlat = (GameObject)Instantiate(revivePlatformPrefab, new Vector2(player.transform.position.x, player.transform.position.y - 1), Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform") {
            if (Random.Range(1, 15) == 1) {
                myEnemy = (GameObject)Instantiate(enemyPrefab, new Vector2(Random.Range(-screenWidth, screenWidth), player.transform.position.y + (screenHeight + Random.Range(0.5f, 0.8f))), Quaternion.identity);
                myEnemy.SetActive(true);
            }
            if (Random.Range(1, 15) == 1) {
                myPowerUp = (GameObject)Instantiate(powerUpPrefab, new Vector2(Random.Range(-screenWidth, screenWidth), player.transform.position.y + (screenHeight + Random.Range(0.5f, 0.8f))), Quaternion.identity);
                myPowerUp.SetActive(true);
            }

            if (Random.Range(1, 10) == 1) {
                myPlat = (GameObject)Instantiate(springPrefab, new Vector2(Random.Range(-screenWidth, screenWidth), collision.transform.position.y + (screenHeight)), Quaternion.identity);
            }
            else if (Random.Range(1, 10) == 1) {
                myPlat = (GameObject)Instantiate(breakPrefab, new Vector2(Random.Range(-screenWidth, screenWidth), collision.transform.position.y + (screenHeight)), Quaternion.identity);
            }
            else {
                myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-screenWidth, screenWidth), collision.transform.position.y + (screenHeight)), Quaternion.identity);
            }
        }
        Destroy(collision.gameObject);
    }
}
