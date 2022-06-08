using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBullet : MonoBehaviour
{
    public float projectileSpeed = 3.0f;
    public Transform destination;
    public Vector3 destination3D;

    public float distance;
    public bool follow = false;

    public float followDistance = 3f;

    // Start is called before the first frame update
    void Start()
    {

        try
        {
            destination = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
            destination3D = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position;
        }
        catch (System.Exception e) {
        
        }
    }

    // Update is called once per frame
    void Update()
    {
        var step = projectileSpeed * Time.deltaTime; // calculate distance to move


        try
        {
            if (follow)
            {
                distance = Vector3.Distance(transform.position, destination.position);

                if (distance <= followDistance)
                {
                    destination3D = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position;
                    follow = false;
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, destination.position, step);

                }

            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, destination3D, step);
                if (transform.position == destination3D)
                    Destroy(this.gameObject);
            }
        }
        catch (MissingReferenceException e) {
            
        }
    }
}
