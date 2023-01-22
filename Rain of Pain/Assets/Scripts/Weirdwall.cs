using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Weirdwall : MonoBehaviour
{
        public GameObject VictoryObject;
        public int cloudCount = 0;
  public float commandTime = 2.0f;
    public TextMeshProUGUI Command;
        public float timeLeft = 12.0f;
        
    public TextMeshProUGUI Timey;
    public GameObject FailureObject;

    // Start is called before the first frame update
    void Start()
    {
        cloudCount = 0;
        VictoryObject.SetActive(false);
        FailureObject.SetActive(false);
    }
  void Update()
    {

         commandTime -= Time.deltaTime;
        Command.text = (commandTime).ToString("0");
        if (commandTime > 1)
        {
          Command.text = "Shoo the Clouds";

        }
         if (commandTime < 1)
        {
          Command.text = "GO! GO! GO!";

        }
        if (commandTime < 0)
        {
          Command.text = "";
          
        }
         timeLeft -= Time.deltaTime;
        Timey.text = (timeLeft).ToString("");


        if (timeLeft < 0)
        {
          FailureObject.SetActive(true);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Cloud")
        {
            cloudCount = cloudCount + 1;
            Destroy(other.gameObject);
            CheckVictory();
            
        }
    }
    void CheckVictory()
    {
        if (cloudCount == 5)
        {
            VictoryObject.SetActive(true);
            Destroy(gameObject);
        }
    }

}