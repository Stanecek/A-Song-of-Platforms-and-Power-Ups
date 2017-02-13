using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using image=UnityEngine.UI.Image;

[RequireComponent(typeof(AudioSource))]
public class HPController : MonoBehaviour {
    public image Healthbar;
    float tmpHealth = 1;

    public LifeManager lifeManagerScript;


    //Audio
    public AudioClip hurtSound;
    new AudioSource audio;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();

        Healthbar = GameObject.Find("MainCamera").transform.FindChild("Canvas").FindChild("HealthBar").GetComponent<image>();

        lifeManagerScript = FindObjectOfType<LifeManager>();
    }
	
	// Update is called once per frame
	void Update () {
        Healthbar.fillAmount = tmpHealth;

        if (Healthbar.fillAmount <= 0)
        {
            lifeManagerScript.TakeLife();
        }
	}

    public void DamagePayer()
    {
        if (Healthbar.fillAmount > 0)
        {
            tmpHealth = tmpHealth - 0.01f;
        }

        //if (audio.clip == hurtSound && !audio.isPlaying)
        //if (!audio.isPlaying)
        //{
            //audio.PlayOneShot(hurtSound, 0.7F);
        //}

        /*
        if (audio.clip == hurtSound && audio.isPlaying)
        {
            //audio.clip = hurtSound; 
            //audio.Stop();
        }
        else
        {
            
            audio.PlayOneShot(hurtSound, 0.7f);
            //audio.clip = hurtSound;   
        }
        */
    }

    public void RestartHealth()
    {
        tmpHealth = 1f;
    }

}

