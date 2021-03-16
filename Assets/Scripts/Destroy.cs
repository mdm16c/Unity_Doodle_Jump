using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    // public Text text;
    public GameObject player;
    public GameObject platformPrefab;
    // public GameObject springPrefab;
    // public GameObject myPlat;
    private GameObject myPlat;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // if(collision.gameObject.name.StartsWith("Platform"))
        // {

        //     if (Random.Range(1, 7) == 1)
        //     {

        //         Destroy(collision.gameObject);
        //         Instantiate(springPrefab, new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (14 + Random.Range(0.2f, 1.0f))), Quaternion.identity);


        //     } else
        //     {

        //         collision.gameObject.transform.position = new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (14 + Random.Range(0.2f, 1.0f)));

        //     }

        // } else if(collision.gameObject.name.StartsWith("Spring"))
        // {

        //     if (Random.Range(1, 7) == 1)
        //     {

        //         collision.gameObject.transform.position = new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (14 + Random.Range(0.2f, 1.0f)));

        //     }
        //     else
        //     {

        //         Destroy(collision.gameObject);
        //         Instantiate(platformPrefab, new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (14 + Random.Range(0.2f, 1.0f))), Quaternion.identity);


        //     }

        // }


        myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (14 + Random.Range(0.5f, 0.8f))), Quaternion.identity);
        Destroy(collision.gameObject);
       //  Debug.Log("Created Normal");

        //    if (Random.Range(1, 6) == 1)
       //       {

        //       Instantiate(springPrefab, new Vector2(myPlat.transform.position.x, myPlat.transform.position.y + 0.4f), Quaternion.identity);

        //   }
    }

}
