using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shoot : MonoBehaviour
{
    private static float CHARGE_TIME = 0.01f;

    public GameObject destroyParticle;
    public GameObject shootPrefab = null;

    public int hp = 10;
    public int bullet = 3;

    float chargeTimer = CHARGE_TIME;
    float chargePercentage = 0;

    public Text hpText;
    public Text bulletText;
    public Slider charge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0) {
            Destroy(this.gameObject);
        }
        chargeTimer -= Time.deltaTime;
        if (chargeTimer < 0) {
            chargePercentage += 0.007f;
            charge.value = chargePercentage;
            chargeTimer = CHARGE_TIME;

            if (chargePercentage >= 1) {
                bullet++;
                chargePercentage = 0;
            }
        }

        hpText.text = hp.ToString();
        bulletText.text = bullet.ToString();

        if (Input.GetKeyDown("down") && bullet > 0) {
            GameObject projectileGameObject = Instantiate(shootPrefab, transform.position, transform.rotation, null);
            projectileGameObject.AddComponent<Ballet>();
            projectileGameObject.gameObject.tag = "Player_Bullet";
            bullet--;
            Destroy(projectileGameObject,60);
            //projectileGameObject.transform.position  = Vector3.MoveTowards(,sun.transform.position, )
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ale");
        if (collision.gameObject.tag == "Planet_Bullet")
        {
            hp--;
            Destroy(collision.gameObject);
            GameObject efect = Instantiate(destroyParticle, transform.position, transform.rotation, null);
            efect.transform.localScale += new Vector3(3f, 3f, 3f);
            Destroy(efect, 3);
        }
    }
}
