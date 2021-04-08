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
    public bool isGameOver;
    public bool onStart = true;
    public Destroyer ds;
    // Start is called before the first frame update
    void Start()
    {
        gameOver.enabled = false;
        restart.gameObject.SetActive(false);
        Time.timeScale = 0.0f;
        ds = gameObject.GetComponent<Destroyer>();
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
            Destroy(GameObject.Find("Player"));
            gameOver.enabled = true;
            restart.gameObject.SetActive(true);
        }
    }

    public void startGame()
    {
        onStart = false;
        Time.timeScale = 1.0f;
    }

    public void restartLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
