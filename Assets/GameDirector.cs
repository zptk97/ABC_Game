using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public GameObject hpGauge1;
    public GameObject hpGauge2;
    public GameObject hpGauge3;
    public GameObject hpGauge4;

    public Sprite ASprite; //A,B,C,D 손 모양 그림
    public Sprite BSprite;
    public Sprite CSprite;
    public Sprite DSprite;

    GameObject Timer;
    float span = 3.0f;
    float delay = 1.0f;
    float delta = 0;
    float delta2 = 0;

    bool attack = false;
    public bool check = true;

    float Damage = 0;
    int Attacktimes = 0;

    void Start () {
        this.player1 = GameObject.Find("Player1");
        this.player2 = GameObject.Find("Player2");
        this.player3 = GameObject.Find("Player3");
        this.player4 = GameObject.Find("Player4");

        this.hpGauge1 = GameObject.Find("hpGauge1");
        this.hpGauge2 = GameObject.Find("hpGauge2");
        this.hpGauge3 = GameObject.Find("hpGauge3");
        this.hpGauge4 = GameObject.Find("hpGauge4");
        this.Timer = GameObject.Find("Timer");
    }
	public void DecreaseHp()
    {

    }
    

	// Update is called once per frame
	void Update () {
        if (attack == false)
        {
            if (this.delta > this.span)
            {
                if(player1.GetComponent<SpriteRenderer>().sprite == player2.GetComponent<SpriteRenderer>().sprite||
                   player1.GetComponent<SpriteRenderer>().sprite == player3.GetComponent<SpriteRenderer>().sprite||
                   player1.GetComponent<SpriteRenderer>().sprite == player4.GetComponent<SpriteRenderer>().sprite)
                {
                    
                    attack = true;
                    this.Timer.GetComponent<Text>().text = "공격 성공";
                    
                }
                else
                {
                    this.Timer.GetComponent<Text>().text = "3";
                }
                this.delta = 0;
            }
            else if (this.delta > this.span / 3.0f * 2.0f)
            {
                this.Timer.GetComponent<Text>().text = "1";
            }
            else if (this.delta > this.span / 3.0f)
            {
                this.Timer.GetComponent<Text>().text = "2";
            }
            else if (this.delta==0)
            {
                this.Timer.GetComponent<Text>().text = "3";
            }
            this.delta += Time.deltaTime;
        }
        else
        {
            this.delta2 += Time.deltaTime;
            if(this.delta2>this.delay)
            {
                //공격 횟수 결정
                if(player1.GetComponent<SpriteRenderer>().sprite == this.ASprite)
                {
                    this.Attacktimes = 1;
                }
                else if(player1.GetComponent<SpriteRenderer>().sprite == this.BSprite)
                {         
                    this.Attacktimes = 2;
                }
                else if(player1.GetComponent<SpriteRenderer>().sprite == this.CSprite)
                {
                    this.Attacktimes = 3;
                }
                else if(player1.GetComponent<SpriteRenderer>().sprite == this.DSprite)
                {
                    this.Attacktimes = 4;
                }
                //데미지 결정
                Damage = Random.Range(0.01f, 0.05f);
                //데미지 입히기
                if(player1.GetComponent<SpriteRenderer>().sprite == player2.GetComponent<SpriteRenderer>().sprite)
                {
                    this.hpGauge2.GetComponent<Image>().fillAmount -= Damage * Attacktimes;
                }
                if(player1.GetComponent<SpriteRenderer>().sprite == player3.GetComponent<SpriteRenderer>().sprite)
                {
                    this.hpGauge3.GetComponent<Image>().fillAmount -= Damage * Attacktimes;
                }
                if (player1.GetComponent<SpriteRenderer>().sprite == player4.GetComponent<SpriteRenderer>().sprite)
                {
                    this.hpGauge4.GetComponent<Image>().fillAmount -= Damage * Attacktimes;
                }
                //공격 종료
                this.delta2 = 0;
                this.delta = 0;
                attack = false;

            }
        }
		if(player1.GetComponent<SpriteRenderer>().sprite== player2.GetComponent<SpriteRenderer>().sprite)
        {
            
        }
	}
}
