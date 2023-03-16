using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class TriggerLevel : MonoBehaviour
{
    public GameObject guiObject;
    public string levelToLoad;
    // Use this for initialization
    void Start()
    {
        guiObject.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            guiObject.SetActive(true);
            if (guiObject.activeInHierarchy == true && Input.GetButtonDown("Use"))
            {
                SceneManager.LoadScene("CyberspaceFight");
            }
        }
    }

    void OnTriggerExit()
    {
        guiObject.SetActive(false);
    }
}