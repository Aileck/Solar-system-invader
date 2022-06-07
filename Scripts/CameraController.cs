using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeCameraLookAtSun(){
        camera1.enabled = true;
        camera2.enabled = false;
    }

    public void changeAroundSun(){
        camera1.enabled = false;
        camera2.enabled = true;
       
    }
}
