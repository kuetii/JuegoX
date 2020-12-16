using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerSelector : MonoBehaviour
{
    public int firstchar;
    public int secondChar;
    public Sprite[] playerSprites;
    public SpriteRenderer player1;
    public SpriteRenderer player2;

    public void selectCampeon(int numero)
    {
        firstchar = numero;   
    }
    public void selectcampeon2(int numero)
    {
        secondChar= numero;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Jugar()
    {
        player1.sprite = playerSprites[firstchar];
        player2.sprite = playerSprites[secondChar];
    }
    public void ChargeMapScene()
    {
        SceneManager.LoadScene(0);
    }
}

