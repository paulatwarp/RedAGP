using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager=GameObject.FindObjectOfType<GameManager>(); 

    }

    public void SingleCard()
    {
        gameManager.CardStack = 1;
    }

    public void DoubleCard()
    {
        gameManager.CardStack = 2;
    }
}
