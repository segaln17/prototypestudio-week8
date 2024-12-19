using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CannonScript : MonoBehaviour
{
    public static CannonScript instance;

    public bool notCannonball = false;

    public int timesFired = 0;
    
    public AudioClip boom;
    
    //other sounds:
    //Catch all: 
    private AudioClip otherSound;
    public AudioClip peopleSound;
    public AudioClip sheepSound;
    public AudioClip gunSound;
    public AudioClip carHonk;
    public AudioClip bugSound;
    public AudioClip priestSound;

    public AudioSource audioManager;

    public GameObject fireEffect;

    public int itemsFired = 0;

    public Button fireButton;
    public Button ammoSceneButton;

    public bool readyToFire = false;

    private string sceneName;
    

    private void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        
        if (currentScene.name != "StoreroomScene")
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        fireButton.gameObject.SetActive(false);
        ammoSceneButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (itemsFired >= 7 && sceneName == "CannonScene1")
        {
            ammoSceneButton.gameObject.SetActive(true);
            //text or button activates to take you to another scene
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fodder"))
        {
            readyToFire = true;
            fireButton.gameObject.SetActive(true);
            
            if (other.gameObject.name == "Sheep")
            {
                notCannonball = true;
                otherSound = sheepSound;
            }

            if (other.gameObject.name == "Gun")
            {
                notCannonball = true;
                otherSound = gunSound;
            }

            if (other.gameObject.name == "Person")
            {
                notCannonball = true;
                otherSound = peopleSound;
            }

            if (other.gameObject.name == "Car")
            {
                notCannonball = true;
                otherSound = carHonk;
            }

            if (other.gameObject.name == "Weevil")
            {
                notCannonball = true;
                otherSound = bugSound;
            }

            if (other.gameObject.name == "Priest")
            {
                notCannonball = true;
                otherSound = priestSound;
            }
            itemsFired++;
            Destroy(other.gameObject);
            
        }
        //Invoke("FireCannon", 1.5f);
        
    }

    public void FireCannon()
    {
        StartCoroutine(WaitToFire());
        audioManager.PlayOneShot(boom);
        timesFired++;
        if (notCannonball)
        {
            audioManager.PlayOneShot(otherSound);
        }
       
        Instantiate(fireEffect, new Vector3(-0.04f, 3.01f, -3.55f), Quaternion.identity);
        fireButton.gameObject.SetActive(false);
        readyToFire = false;
    }

    IEnumerator WaitToFire()
    {
        yield return new WaitForSeconds(1.5f);
    }

    public void AmmoScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
