using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetShoot : MonoBehaviour
{
    public GameObject spawnPrefab = null;
    public float spawnTime = 5.0f;

    private float nextSpawn = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // update the time until nextSpawn
        nextSpawn += Time.deltaTime;

        // if time to spawn
        if (nextSpawn > spawnTime)
        {
            // Spawn the gameObject at the spawners current position and rotation
            GameObject projectileGameObject = Instantiate(spawnPrefab, transform.position, transform.rotation, null);
            if (this.gameObject.tag == "Sun") {
                projectileGameObject.GetComponent<PlanetBullet>().follow = true;
            }
            // reset the time until nextSpawn
            nextSpawn = 0f;
        }
    }
}
