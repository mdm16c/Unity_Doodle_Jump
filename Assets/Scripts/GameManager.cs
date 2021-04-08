using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text title;
    public Text gameOver;
    public Button start;
    public Button restart;
    public Button menu;
    public bool isGameOver;
    public bool onStart = true;
    public Destroy ds;
    public Controller cont;
    public GameObject player;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        ds = player.GetComponentInChildren<Destroy>();
        cam = GameObject.Find("Camera");
        cont = player.GetComponent<Controller>();
        gameOver.enabled = false;
        restart.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        Time.timeScale = 0.0f;
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
            player.transform.position = new Vector2(0, 0);
            Time.timeScale = 0.0f;
            gameOver.enabled = true;
            restart.gameObject.SetActive(true);
            menu.gameObject.SetActive(true);
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
        isGameOver = false;
        gameOver.enabled = false;
        restart.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        cont.topScore = 0.0f;
        GameObject[] thing = GameObject.FindGameObjectsWithTag("Platform");
        foreach(GameObject mything in thing) {
            Destroy(mything);
        }
        ds.createStartingPlats();
        cam.transform.position = new Vector3(cam.transform.position.x, 1.5f, cam.transform.position.z);
        Time.timeScale = 1.0f;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }
}