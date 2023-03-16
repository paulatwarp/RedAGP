using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator anim;
    public CharacterController controller;
    public GameObject PunchBall;

    public void PunchBallShow()
    {
        PunchBall.SetActive(true);
    }
    public void PunchBallHide()
    {
        PunchBall.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

  
}
