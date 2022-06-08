using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballet : MonoBehaviour
{
    GameObject sun;
    [Tooltip("The distance this projectile will move each second in meters.")]
    public float projectileSpeed = 3.0f;

    [Tooltip("How far away from the main camera before destroying the projectile gameobject in meters.")]
    public float destroyDistance = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        sun = GameObject.FindGameObjectWithTag("Sun");
    }

    // Update is called once per frame
    void Update()
    {
        var step = projectileSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, sun.transform.position, step);

    }

    private void OnCollisionEnter(Collision collision)
    {;
        if (collision.gameObject.GetComponent<Planet>() != null) {
            collision.gameObject.GetComponent<Planet>().collision();
        }
    }
}
