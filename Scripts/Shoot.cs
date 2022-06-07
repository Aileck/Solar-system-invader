using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shoot : MonoBehaviour
{
    private static float CHARGE_TIME = 0.01f;

    public GameObject shootPrefab = null;
    int hp = 5;
    int bullet = 3;
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
        chargeTimer -= Time.deltaTime;
        if (chargeTimer < 0) {
            Debug.Log("ww");
            chargePercentage += 0.005f;
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
            //projectileGameObject.transform.position  = Vector3.MoveTowards(,sun.transform.position, )
        }
    }
}
