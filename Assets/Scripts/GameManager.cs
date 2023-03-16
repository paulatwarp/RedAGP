using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;


public enum PlayingCards
{
   Rock,Paper,Scissors
}
public class GameManager : MonoBehaviour
{
    public List<PlayingCards> player1Cards;
    public List<PlayingCards> player2Cards;
    public Reveal[] Cards;
    //public RevealP2 Enemy;
    private List<CommandBase> playerAction = new List<CommandBase>();
    private List<CommandBase> enemyAction = new List<CommandBase>();

    private int[] cardNumbers = new[] {0, 1, 2};
    private bool EnemySelected = false;
    private bool PlayerSelected = false;
    

    public GameObject PlayButton;
    [HideInInspector]public int CardStack = 0;
    private int CardStackIndex = 0;
    private string playercombo = "";
    private string enemycombo = "";
    public Player2 player;

    public Player2 opponent;
    // Start is called before the first frame update
    void Start() 
    {
        Cards = GameObject.FindObjectsOfType<Reveal>();

        Reset();

        //enemycombo = "Rock";
        //StartCoroutine(RevealPlayerCards());
    }

    public void CardSelected(Character character,CommandBase action)
    {
        // if (CardStack == 0)
        // {
        //     return;
        // }
        if (character == Character.player)
        {
            PlayerSelected = true;
            if (CardStackIndex<CardStack)
            {

                playerAction.Add(action);
                CardStackIndex += 1;
                if (playercombo == "")
                {
                    playercombo += action._name;
                }
                else
                {
                    playercombo += "+" + action._name;
                }
                print(playercombo);
            }
            if (CardStack == 1 && CardStackIndex == CardStack)
            {
                var combo = playercombo + "+" + enemycombo; 
                print("result: " + Combo.GetComboResult(combo));
                player.CurrentHealth -= Combo.GetComboResult(combo).Item1;
                opponent.CurrentHealth -= Combo.GetComboResult(combo).Item2;
                PlayButton.SetActive(true);
            } else if (CardStack == 2 && CardStackIndex == CardStack)
            {
                var combo = playercombo + "," + enemycombo;
                print("Combo: "+combo);
                print("result: "+ Combo.GetComboResult(combo));
                player.CurrentHealth -= Combo.GetComboResult(combo).Item1;
                opponent.CurrentHealth -= Combo.GetComboResult(combo).Item2;
                print(action._name);
           
                print(playercombo);
                if (playerAction[0]._name == playerAction[1]._name)
                {
                    print("Equal");
                    PlayButton.SetActive(true);
                }
                else
                {
                    print( "Not Equal");
                }
            }
            
        }
        if (character == Character.enemy)
        {
            EnemySelected = true;
            enemyAction.Add(action);
            if (enemycombo == "")
            {
                enemycombo += action._name;
            }
            else
            {
                enemycombo += "+" + action._name;
            }
            print("enemycombo: " + enemycombo);
        }

        
        if (PlayerSelected==true && EnemySelected==true)
        {
            PlayButton.SetActive(true);
        }


    }
    
    
    
    // Update is called once per frame
    void Update()
    {
        
    }

     public void ShuffleCards()
    {
        for (int i = 0; i < 100; i++)
        {
            var r1 = Random.Range(0, 3);
            var r2 = Random.Range(0, 3);
            var temp = cardNumbers[r1];
            cardNumbers[r1] = cardNumbers[r2];
            cardNumbers[r2] = temp;
        }
        
    }

    public void FIGHT()
    {
        playerAction[0].Execute();
        StartCoroutine(ResetDelay());
        //enemyAction[0].Execute();
    }

    IEnumerator ResetDelay()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 6; i++)
        {
            Cards[i].Reset();
            //Enemy.Revealface(i);
        }
        Reset();
    }

    public void Reset()
    {
        playercombo = "";
        enemycombo = "";
        CardStack = 0;
        CardStackIndex = 0;
        player1Cards.Clear();
        player2Cards.Clear();
        playerAction.Clear();
        enemyAction.Clear();
        
        
        for (int i = 0; i < 6; i++)
        {
            ShuffleCards();
            player1Cards.Add((PlayingCards)cardNumbers[0]);
        }
       
        for (int i = 0; i < 6; i++)
        {
            ShuffleCards();
            player2Cards.Add((PlayingCards)cardNumbers[0]);
        }
        
        PlayButton.SetActive(false);
        Canvas.ForceUpdateCanvases();

        StartCoroutine(RevealPlayerCards());
    }

    IEnumerator RevealPlayerCards()
    {
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Cards[i].Revealface(player1Cards[i]);
            //Cards[i].Revealface(player2Cards[i]);
            //Enemy.Revealface(i);
        }
        
        //CardSelected(Character.enemy,);
    }

}
