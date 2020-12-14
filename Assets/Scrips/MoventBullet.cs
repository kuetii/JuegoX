using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoventBullet : MonoBehaviour
{
    public int speed;
    public Vector3 Direccion;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        {
            transform.position = transform.position + Direccion * speed * Time.deltaTime;
           
        }
    }

}
