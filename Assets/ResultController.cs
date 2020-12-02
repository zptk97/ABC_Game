using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour {
    public GameObject Timer;
    public GameObject GameDirector;

    public bool End = false;
    float delta=0,delta2=0;
    float delay = 1.0f;
    // Use this for initialization
    void Start () {
        this.Timer = GameObject.Find("Timer");
        this.GameDirector = GameObject.Find("GameDirector");
    }
	
	// Update is called once per frame
	void Update () {
		if(Timer.GetComponent<TimerController>().attack)
        {
            if (this.delta !=-1)
            {
                this.delta += Time.deltaTime;
            }
            if (this.delta > this.delay)
            {
                GameDirector.GetComponent<GameDirector>().DecreaseHp(Timer.GetComponent<TimerController>().player);
                this.delta = -1;
                End = true;
            }
            if (End)
            {
                if (this.delta2 != -1)
                {
                    this.delta2 += Time.deltaTime;
                }
                if (this.delta2 > this.delay)
                {
                    Timer.GetComponent<TimerController>().attack = false;
                    GetComponent<Text>().text = "";
                    End = false;
                    this.delta = 0;
                    this.delta2 = 0;
                }
            }

        }
	}
}
