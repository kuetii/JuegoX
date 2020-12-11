using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject powerUp;
    float currentPwupCD;
    // Start is called before the first frame update
    void Start()
    {
        currentPwupCD = Random.Range(10, 11);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, -1f));
        

        if (currentPwupCD <= 0)
        {
            Instantiate(powerUp, new Vector2(Random.Range(-2.5f, 2.5f), 9.5f), powerUp.transform.rotation);
            currentPwupCD = Random.Range(1, 5);
        }
        if (currentPwupCD > 0)
        {
            currentPwupCD -= Time.deltaTime;
        }
    }
}

