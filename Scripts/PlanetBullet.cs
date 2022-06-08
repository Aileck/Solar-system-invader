using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBullet : MonoBehaviour
{
    public float projectileSpeed = 3.0f;
    public Transform destination;
    public Vector3 destination3D;

    public bool isSun = false;
    // Start is called before the first frame update
    void Start()
    {
        if(isSun)
            destination = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
        else
            destination3D = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var step = projectileSpeed * Time.deltaTime; // calculate distance to move

        if(isSun)
            transform.position = Vector3.MoveTowards(transform.position, destination.position, step);
        else
            transform.position = Vector3.MoveTowards(transform.position, destination3D, step);
    }
}
