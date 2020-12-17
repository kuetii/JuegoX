using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnestrellitas : MonoBehaviour
{
    public GameObject Estrella;
    float estrellatime;
    public GameObject[] spawners;
    // Start is called before the first frame update
    void Start()
    {
        estrellatime = Random.Range(10, 11);
    }

    // Update is called once per frame
    void Update()
    {
        if (estrellatime <= 0)
        {
            Instantiate(Estrella, spawners[Random.Range(0, spawners.Length)].transform.position, Estrella.transform.rotation);
            estrellatime = Random.Range(1, 2);
        }
        if (estrellatime > 0)
        {
            estrellatime-= Time.deltaTime;
        }
    }
}
