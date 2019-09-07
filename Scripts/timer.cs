using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text timerText;
    public float time = 900;
    public bool gameOver = false;
    GameObject skeleton;
    public GameObject currentSong;   
    public GameObject timerObj;
    AudioSource currentSource;
    AudioSource timerSource;    
    string minutes;
    string seconds;
    void Start()
    {
        skeleton = GameObject.Find("Disappointed");
        skeleton.SetActive(false);
        StartCoundownTimer();
        currentSource = currentSong.GetComponent<AudioSource>();       
        timerSource = timerObj.GetComponent<AudioSource>();
    }

    void StartCoundownTimer()
    {
        if (timerText != null)
        {
            time = 900;
            timerText.text = "15:00";
            InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
        }
    }

    void UpdateTimer()
    {
        if (timerText != null)
        {
            if(gameOver == false)
            {
                time -= Time.deltaTime;
                minutes = Mathf.Floor(time / 60).ToString("00");
                seconds = (time % 60).ToString("00");
                //string fraction = ((time * 100) % 100).ToString("000");
                timerText.text = minutes + ":" + seconds;
            }

            if (minutes.Equals("00") && seconds.Equals("00"))
            {
                gameOver = true;
                timerSource.Stop();
                minutes = "00";
                seconds = "00";
                currentSource.Stop();              
                skeleton.SetActive(true);
                Debug.Log("Game Over!");
                timerText.text = minutes + ":" + seconds;
            }
        }
    }

}

