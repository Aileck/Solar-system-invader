using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Planet : MonoBehaviour
{
    // Start is called before the first frame update
    public int hp = 1;
    public GameObject destroyParticle;
    public float destroyTime = 2f;

    public Text hpText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "Sun")
        {
            hpText.text = hp.ToString();
        }
        if (hp == 0) {
            this.GetComponent<RotateAround>().speed = 0;
            Destroy(this.gameObject, 1);
        }
    }

    public void collision()
    {
        hp--;
        GameObject efect = Instantiate(destroyParticle, transform.position, transform.rotation, null);
        efect.transform.localScale += new Vector3(3f, 3f, 3f); 
        Destroy(efect,3);
    }

}
