﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameManagerThing : MonoBehaviour, IUnityAdsListener
{
    public Text title;
    public Text gameOver;
    public Button start;
    public Button restart;
    public Button menu;
    public bool isGameOver = false;
    public bool onStart = true;
    public Destroy ds;
    public Controller cont;
    public GameObject player;
    public GameObject cam;
    private bool needToShowAd = true;
    private string gameId = "4091475";
    public bool adTestMode = true;
    public moveBG mbg;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        ds = player.GetComponentInChildren<Destroy>();
        cam = GameObject.Find("Camera");
        cont = player.GetComponent<Controller>();
        mbg = player.GetComponent<moveBG>();
        gameOver.enabled = false;
        restart.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        Time.timeScale = 0.0f;
        Advertisement.Initialize(gameId, adTestMode);
        Advertisement.AddListener (this);
    }

    public void OnUnityAdsReady (string placementId) {
        
    }

    public void OnUnityAdsDidError (string message) {
        // Log the error.
    }

    public void OnUnityAdsDidStart (string placementId) {
        // Optional actions to take when the end-users triggers an ad.
    } 

    public void OnUnityAdsDidFinish (string surfacingId, ShowResult showResult) {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished) {
            // Reward the user for watching the ad to completion.
            Debug.Log("The ad was finished.");
        }
        else if (showResult == ShowResult.Skipped) {
            // Do not reward the user for skipping the ad.
            Debug.Log("The ad was skipped.");
        }
        else if (showResult == ShowResult.Failed) {
            Debug.Log("The ad did not finish due to an error.");
        }
    }

    public void OnDestroy() {
        Advertisement.RemoveListener(this);
    }

    public void showVideoAd() {
        if (Advertisement.IsReady("video")) {
            Advertisement.Show("video");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!onStart)
        {
            title.enabled = false;
            start.gameObject.SetActive(false);
        }
        if(isGameOver)
        {
            player.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            player.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            player.transform.position = new Vector2(0, 0);
            Time.timeScale = 0.0f;
            gameOver.enabled = true;
            restart.gameObject.SetActive(true);
            menu.gameObject.SetActive(true);
            if (needToShowAd) {
                needToShowAd = false;
                showVideoAd();
            }
        }
    }

    public void startGame()
    {
        onStart = false;
        ds.createStartingPlats();
        Time.timeScale = 1.0f;
    }

    public void restartLevel()
    {
        mbg.resetBG();
        isGameOver = false;
        gameOver.enabled = false;
        restart.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        cont.topScore = 0.0f;
        GameObject[] thing = GameObject.FindGameObjectsWithTag("Platform");
        foreach(GameObject mything in thing) {
            Destroy(mything);
        }
        thing = GameObject.FindGameObjectsWithTag("Powerup");
        foreach(GameObject mything in thing) {
            Destroy(mything);
        }
        thing = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject mything in thing) {
            Destroy(mything);
        }
        ds.createStartingPlats();
        cam.transform.position = new Vector3(cam.transform.position.x, 1.5f, cam.transform.position.z);
        Time.timeScale = 1.0f;
        needToShowAd = true;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }
}