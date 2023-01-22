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
    public GameObject EndscreenObject;
    public GameObject EndscreenObject2;

    public AudioClip startSound;
    public AudioClip hitSound;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip backgroundSound;
       public AudioSource audioSource;
              public AudioSource audioSource2;


    // Start is called before the first frame update
    void Start()
    {
        cloudCount = 0;
        VictoryObject.SetActive(false);
        FailureObject.SetActive(false);
        EndscreenObject.SetActive(false);
        EndscreenObject2.SetActive(false);

        audioSource.clip = startSound;
        audioSource.Play();
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

     if (timeLeft < 10)
        {
audioSource.clip = backgroundSound;
    if (!audioSource.isPlaying)
    {
      audioSource.Play();
    }        

        }

        if (timeLeft < 0)
        {
          FailureObject.SetActive(true);
          EndscreenObject2.SetActive(true);
          Destroy(gameObject);
           audioSource.clip = loseSound;
        audioSource.Play();
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Cloud")
        {
          
            cloudCount = cloudCount + 1;
            Destroy(other.gameObject);
            CheckVictory();
        audioSource2.clip = hitSound;
        audioSource2.Play();
            
        }
    }
    void CheckVictory()
    {
        if (cloudCount == 5)
        {
            VictoryObject.SetActive(true);
            Destroy(gameObject);
EndscreenObject.SetActive(true);
audioSource.clip = winSound;
        audioSource.Play();
          
        }
    }

}