using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {
    public bool attack = false;
    float delta;
    float delta2;
    float delta3;
    float span = 3.0f;
    float delay = 1.0f;

    bool change = false;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject player;

    public GameObject AButton;
    public GameObject BButton;
    public GameObject CButton;
    public GameObject DButton;

    public int turn = 1;

    public GameObject GameDirector;
    // Use this for initialization
    void Start () {
        this.player1 = GameObject.Find("Player1");
        this.player2 = GameObject.Find("Player2");
        this.player3 = GameObject.Find("Player3");
        this.player4 = GameObject.Find("Player4");
        this.GameDirector = GameObject.Find("GameDirector");
        this.AButton = GameObject.Find("AButton");
        this.BButton = GameObject.Find("BButton");
        this.CButton = GameObject.Find("CButton");
        this.DButton = GameObject.Find("DButton");
    }
	
	// Update is called once per frame
	void Update () {
       
        if (attack == false)
        {
            this.delta2 = 0;
            if (this.delta > this.span)
            {
                //각 플레이어 손 모양 변경
                if (this.change == false)
                {
                    this.player2.GetComponent<AIController>().ShapeChange();
                    this.player3.GetComponent<AIController>().ShapeChange();
                    this.player4.GetComponent<AIController>().ShapeChange();
                    this.change = true;
                }
                //플레이어 손모양 변경버튼 비활성화
                this.AButton.GetComponent<Button>().interactable = false;
                this.BButton.GetComponent<Button>().interactable = false;
                this.CButton.GetComponent<Button>().interactable = false;
                this.DButton.GetComponent<Button>().interactable = false;
                switch (turn)
                {
                    case 1:
                        this.player = this.player1;
                        break;
                    case 2:
                        this.player = this.player2;
                        break;
                    case 3:
                        this.player = this.player3;
                        break;
                    case 4:
                        this.player = this.player4;
                        break;
                    default:
                        break;
                }
                if (GameDirector.GetComponent<GameDirector>().CheckSuccess(player))
                {

                    attack = true;
                    this.GetComponent<Text>().text = "공격 성공!!";

                }
                else
                {
                    this.GetComponent<Text>().text = "공격 실패...다음 턴";
                    this.delta3 += Time.deltaTime;
                    if (this.delta3 > this.delay)
                    {
                            if (turn < 4)
                            {
                                turn++;
                            }
                            else
                            {
                                turn = 1;
                            }
                        this.GetComponent<Text>().text = "3";
                        this.delta3 = 0;
                        this.delta = 0;
                        this.change = false;
                        this.AButton.GetComponent<Button>().interactable = true;
                        this.BButton.GetComponent<Button>().interactable = true;
                        this.CButton.GetComponent<Button>().interactable = true;
                        this.DButton.GetComponent<Button>().interactable = true;
                    }
                }
            }
            else if (this.delta > this.span / 3.0f * 2.0f)
            {
                this.GetComponent<Text>().text = "1";
            }
            else if (this.delta > this.span / 3.0f)
            {
                this.GetComponent<Text>().text = "2";
            }
            else if (this.delta == 0)
            {
                this.GetComponent<Text>().text = "3";
            }
            this.delta += Time.deltaTime;
        }
        else
        {
            this.delta2 += Time.deltaTime;
            if (this.delta2 > this.delay)
            {
                this.GetComponent<Text>().text = "";
                this.delta = 0;
                this.change = false;
                this.AButton.GetComponent<Button>().interactable = true;
                this.BButton.GetComponent<Button>().interactable = true;
                this.CButton.GetComponent<Button>().interactable = true;
                this.DButton.GetComponent<Button>().interactable = true;
            }

        }
    }
}
