
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    public static Dictionary<string, string[]> combos=new Dictionary<string, string[]>();

    private void Start()
    {
        //Single Combos
        combos.Add("Rock+Rock", new string[] { "5", "5" });
        combos.Add("Rock+Paper", new string[] { "0", "2" });
        combos.Add("Rock+Scissors", new string[] { "2", "2" });
        combos.Add("Scissors+Rock", new string[] { "2", "2" });
        combos.Add("Scissors+Scissors", new string[] { "5", "5" });
        combos.Add("Scissors+Paper", new string[] { "5", "0" });
        combos.Add("Paper+Scissors", new string[] { "5", "0" });
        combos.Add("Paper+Paper", new string[] { "0", "0" });
        combos.Add("Paper+Rock", new string[] { "2", "0" });

        //double combos
        combos.Add("Rock,Rock+Rock", new string[] { "2", "5" });
        combos.Add("Rock+Rock,Rock", new string[] { "5", "2" });
        combos.Add("Rock+Rock,Paper", new string[] { "0", "2" });
        combos.Add("Paper,Rock+Rock", new string[] { "2", "0" });
        combos.Add("Rock+Rock,Scissors", new string[] { "5", "2" });
        combos.Add("Scissors,Rock+Rock", new string[] { "2", "5" });
        combos.Add("Scissors,Scissors+Scissors", new string[] { "4","2" });
        combos.Add("Scissors+Scissors,Scissors", new string[] { "2","4" });
        combos.Add("Scissors+Scissors,Rock+Rock", new string[] { "5","5" });
        combos.Add("Rock+Rock,Scissors+Scissors", new string[] { "5","5" });
        combos.Add("Scissors+Scissors,Paper+Paper", new string[] { "0","0" });
        combos.Add("Scissors+Scissors,Rock", new string[] { "0","2" });
        combos.Add("Rock,Scissors+Scissors", new string[] { "2","0" });
        combos.Add("Scissors+Scissors,Paper", new string[] { "0","5" });
        combos.Add("Paper,Scissors+Scissors", new string[] { "5","0" });
        combos.Add("Paper+Paper,Scissors+Scissors", new string[] { "0", "0" });
        combos.Add("Paper+Paper,Paper", new string[] { "0", "0" });
        combos.Add("Paper,Paper+Paper", new string[] { "0", "0" });
        combos.Add("Paper+Paper,Scissors", new string[] { "3", "0" });
        combos.Add("Scissors,Paper+Paper", new string[] { "0", "3" });
        combos.Add("Paper+Paper,Rock", new string[] { "2", "0" });
    
    }

    public static Tuple<int,int> GetComboResult(string combo)
    {
        return Tuple.Create(int.Parse(combos[combo][0]), Int32.Parse(combos[combo][1]));
    }

}
