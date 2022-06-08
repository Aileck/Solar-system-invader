using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject sun;

    public int planetNumber;

    public bool buff1 = false; //Planet number <= 2 || faster
    public bool buff2 = false; //Planet number = 0  || change direction lower
    public bool buff3 = false; //Sun HP <= 10       || change direction lower
    public bool buff4 = false; //Sun HP <= 5        || faster

    public GameObject win;
    public GameObject lose;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            planetNumber = GameObject.FindGameObjectsWithTag("Planet").Length;

            if (planetNumber <= 2 && buff1 == false)
            {
                sun.GetComponent<PlanetShoot>().spawnTime -= 0.4f;
                buff1 = true;
            }
            if (planetNumber <= 1 && buff2 == false)
            {
                sun.GetComponent<PlanetShoot>().spawnTime -= 0.4f;
                buff2 = true;
            }

            if (sun.GetComponent<Planet>().hp <= 10 && buff3 == false)
            {
                sun.GetComponent<PlanetShoot>().spawnTime -= 0.4f;
                buff3 = true;

            }
            if (sun.GetComponent<Planet>().hp <= 15 && buff4 == false)
            {
                sun.GetComponent<PlanetShoot>().spawnTime -= 0.4f;
                sun.GetComponent<PlanetShoot>().spawnTime--;
                buff4 = true;
            }

            if (sun.GetComponent<Planet>().hp <= 0)
            {
                win.gameObject.SetActive(true);
                player.GetComponent<Shoot>().enabled = false;
            }

            if (player.GetComponent<Shoot>().hp <= 0)
            {
                lose.gameObject.SetActive(true);
                sun.GetComponent<Planet>().enabled = false;
                sun.GetComponent<PlanetShoot>().enabled = false;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
        catch (MissingReferenceException E) {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
    }
}
