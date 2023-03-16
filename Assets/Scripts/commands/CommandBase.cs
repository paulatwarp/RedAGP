using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CommandBase
{
    public string _name;
    public Animator _anim;

    public void Setup(string name, Animator anim)
    {
        _name = name;
        _anim = anim;
    }
    public abstract void Execute();
}

public class Rock : CommandBase
{
    public override void Execute()
    {
        _anim.SetTrigger("Punch");
        _anim.speed = 1f;
    }
}

public class Paper : CommandBase
{
    public override void Execute()
    {
        _anim.SetTrigger("Block");
        _anim.speed = 1f; 
    }
}

public class Scissors : CommandBase
{
    public override void Execute()
    {
        _anim.SetTrigger("Evade");
        _anim.speed = 1f;
    }
}
