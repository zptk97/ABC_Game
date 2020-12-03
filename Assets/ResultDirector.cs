using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultDirector : MonoBehaviour {
    public GameObject[] Name = new GameObject[4];
    public GameObject[] Hp = new GameObject[4];
    public GameObject Data;
	// Use this for initialization
	void Start () {
        Name[0] = GameObject.Find("Name1");
        Name[1] = GameObject.Find("Name2");
        Name[2] = GameObject.Find("Name3");
        Name[3] = GameObject.Find("Name4");

        Hp[0] = GameObject.Find("Hp1");
        Hp[1] = GameObject.Find("Hp2");
        Hp[2] = GameObject.Find("Hp3");
        Hp[3] = GameObject.Find("Hp4");

        Data = GameObject.Find("Data");

        for (int i = 0; i < 4; i++)
        {
           Name[i].GetComponent<Text>().text = Data.GetComponent<Data>().Name[i];
            Hp[i].GetComponent<Text>().text = Data.GetComponent<Data>().hpGauge[i].ToString();
        }

        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
