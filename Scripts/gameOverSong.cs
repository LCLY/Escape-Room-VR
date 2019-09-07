using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverSong : MonoBehaviour
{
    timer timerScript;
    public GameObject timerObj; 
    AudioSource failSource;
    bool playMusic = false;
    // Start is called before the first frame update
    void Start()
    {
        timerScript = timerObj.GetComponent<timer>();
        failSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timerScript.gameOver == true)
        {
            if(playMusic == false)
            {
                failSource.Play();
                playMusic = true;
            }
        }
        
    }
}
