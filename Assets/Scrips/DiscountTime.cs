using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DiscountTime : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 60f;



    [SerializeField] Text countdownText;


    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString();

        
    }
}


