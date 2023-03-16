using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTrigger : MonoBehaviour
{
 public GameObject uiObject;
    void Start()
    {
       uiObject.SetActive(false); 
    }

   void OnTriggerEnter(Collider player){
          if(player.gameObject.tag=="Player"){
                uiObject.SetActive(true);
                StartCoroutine("WaitForSec");
          }
   }
   IEnumerator WaitForSec()
   {
    yield return new WaitForSeconds(2);

    Destroy(uiObject);
    Destroy(gameObject);
   }
}
