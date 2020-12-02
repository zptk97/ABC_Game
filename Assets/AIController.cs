using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {
    int random;

	// Use this for initialization
	void Start () {
		
	}
	
    public void ShapeChange()
    {
        random = Random.Range(1, 5);
        if(random==1)
        GetComponent<PlayerController>().AButtonDown();
        else if(random==2)
            GetComponent<PlayerController>().BButtonDown();
        else if(random==3)
            GetComponent<PlayerController>().CButtonDown();
        else if(random==4)
            GetComponent<PlayerController>().DButtonDown();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
