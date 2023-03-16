using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using System;

public enum Character
{
    player,enemy
}

public class Reveal : MonoBehaviour
{
    public Image Back;
    public Sprite[] faces;
    private bool reveal = false;
    public Image Face;
    //public Card Card;
    public Animator anim;
    [FormerlySerializedAs("GameManager")] public GameManager gameManager;
    public Character character;
    [HideInInspector]public CommandBase action;

    void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void Reset()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        Back.enabled = true;
        reveal = false;
    }

    public void Buttonclicked()
    {
        print(character.ToString());
        print(action._name);
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameManager.CardSelected(character, action);
    }

    public void Revealface(PlayingCards card)
    {

            PlayerReveal(card);

    }


    private void PlayerReveal(PlayingCards card)
    {
        if (reveal == false) 
        {
            Back.enabled = false;
            reveal = true;
            var doaction=DOACTION(card);
            Face.sprite = faces [doaction.Item1];
            action = doaction.Item2;
        }
        else
        {
            action.Execute();
            Back.enabled = true;
            reveal = false;
        } 
    }
    // private void EnemyReveal(PlayingCards card)
    // {
    //     if (reveal == false) 
    //     {
    //         Back.enabled = false;
    //         reveal = true;
    //         var doaction=DOACTION(card);
    //         Face.sprite = faces [doaction.Item1];
    //         action = Tuple.Create(doaction.Item2, doaction.Item3); 
    //         gameManager.CardSelected(Character.enemy,action);
    //     }
    //     else
    //     {
    //         action.Item2.Invoke();
    //         Back.enabled = true;
    //         reveal = false;
    //     }
    // }
    public (int,CommandBase) DOACTION(PlayingCards Card)
    {
        switch (Card)
        {
            case PlayingCards.Rock:
                var rock = new Rock(); 
                rock.Setup("Rock", anim); 
                return (0,rock);
            case PlayingCards.Paper:
                var paper = new Paper(); 
                paper.Setup("Paper", anim);
                return (1,paper);
            case PlayingCards.Scissors:
                var scissors = new Scissors(); 
                scissors.Setup("Scissors", anim);
                return (2,scissors);
            default:
                var def = new Scissors(); 
                def.Setup("Scissors", anim);
                return (2,def);  
        }
    }
    
    /*
    void Rock()
    {
        anim.SetTrigger("Punch");
        anim.speed = 1f;
        
        //damage
    }
    
    void Paper()
    {
        anim.SetTrigger("Block");
        anim.speed = 1f;
        
        //damage
    }
    void Scissors()
    {
        anim.SetTrigger("Evade");
        anim.speed = 1f;
        
        //damage
    }
   */ 



}
