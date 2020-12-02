using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnChecker : MonoBehaviour {
    GameObject Timer;
    GameObject Turn;

	// Use this for initialization
	void Start () {
        this.Timer = GameObject.Find("Timer");
        this.Turn = GameObject.Find("Turn");
	}
	
	// Update is called once per frame
	void Update () {
		switch(Timer.GetComponent<TimerController>().turn)
        {
            case 1:
                transform.position = new Vector3(0.0f, -1.1f, 0.0f);
                break;
            case 2:
               transform.position = new Vector3(-1.5f, 1.8f, 0.0f);
                break;
            case 3:
                transform.position = new Vector3(0.0f, 3.8f, 0.0f);
                break;
            case 4:
                transform.position = new Vector3(1.5f, 1.8f, 0.0f);
                break;
            default:
                break;
        }
	}
}
