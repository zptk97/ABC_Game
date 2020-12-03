using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject[] Rank = new GameObject[4];
    public GameObject Data;

    public GameObject hpGauge1;
    public GameObject hpGauge2;
    public GameObject hpGauge3;
    public GameObject hpGauge4;

    public Sprite ASprite; //A,B,C,D 손 모양 그림
    public Sprite BSprite;
    public Sprite CSprite;
    public Sprite DSprite;

    GameObject Timer;
    public GameObject Result;
    float span = 3.0f;
    float delay = 1.0f;
    float delta = 0;
    float delta2 = 0;

    bool attack = false;
    public bool check = true;
    public bool GameEnd = false;
    public bool RankCheck = false;

    float Damage = 0;
    int Attacktimes = 0;
    public float[] hpGauge = new float[4];

    void Start () {
        this.player1 = GameObject.Find("Player1");
        this.player2 = GameObject.Find("Player2");
        this.player3 = GameObject.Find("Player3");
        this.player4 = GameObject.Find("Player4");
        this.Data = GameObject.Find("Data");

        this.hpGauge1 = GameObject.Find("hpGauge1");
        this.hpGauge2 = GameObject.Find("hpGauge2");
        this.hpGauge3 = GameObject.Find("hpGauge3");
        this.hpGauge4 = GameObject.Find("hpGauge4");
        this.Timer = GameObject.Find("Timer");
        this.Result = GameObject.Find("Result");

        this.Rank[0] = player1;
        this.Rank[1] = player2;
        this.Rank[2] = player3;
        this.Rank[3] = player4;
    }
    public bool CheckSuccess(GameObject player)
    {

        if(player==this.player1)
        {
            if (player1.GetComponent<SpriteRenderer>().sprite == player2.GetComponent<SpriteRenderer>().sprite ||
             player1.GetComponent<SpriteRenderer>().sprite == player3.GetComponent<SpriteRenderer>().sprite ||
             player1.GetComponent<SpriteRenderer>().sprite == player4.GetComponent<SpriteRenderer>().sprite)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if(player==this.player2)
        {
            if (player2.GetComponent<SpriteRenderer>().sprite == player1.GetComponent<SpriteRenderer>().sprite ||
             player2.GetComponent<SpriteRenderer>().sprite == player3.GetComponent<SpriteRenderer>().sprite ||
             player2.GetComponent<SpriteRenderer>().sprite == player4.GetComponent<SpriteRenderer>().sprite)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (player == this.player3)
        {
            if (player3.GetComponent<SpriteRenderer>().sprite == player1.GetComponent<SpriteRenderer>().sprite ||
             player3.GetComponent<SpriteRenderer>().sprite == player2.GetComponent<SpriteRenderer>().sprite ||
             player3.GetComponent<SpriteRenderer>().sprite == player4.GetComponent<SpriteRenderer>().sprite)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (player == this.player4)
        {
            if (player4.GetComponent<SpriteRenderer>().sprite == player1.GetComponent<SpriteRenderer>().sprite ||
            player4.GetComponent<SpriteRenderer>().sprite == player2.GetComponent<SpriteRenderer>().sprite ||
            player4.GetComponent<SpriteRenderer>().sprite == player3.GetComponent<SpriteRenderer>().sprite)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

	public void DecreaseHp(GameObject player)
    {
        //공격 횟수 결정
        if (player.GetComponent<SpriteRenderer>().sprite == this.ASprite)
        {
            this.Attacktimes = 1;
        }
        else if (player.GetComponent<SpriteRenderer>().sprite == this.BSprite)
        {
            this.Attacktimes = 2;
        }
        else if (player.GetComponent<SpriteRenderer>().sprite == this.CSprite)
        {
            this.Attacktimes = 3;
        }
        else if (player.GetComponent<SpriteRenderer>().sprite == this.DSprite)
        {
            this.Attacktimes = 4;
        }
        //데미지 결정
        Damage = Random.Range(5, 10) / 100.0f;
        
        this.Result.GetComponent<Text>().text = Damage*100+ " 대미지!!"+Attacktimes+" 대";
        //데미지 입히기
        if (player==this.player1)
        {
            if (player.GetComponent<SpriteRenderer>().sprite == player2.GetComponent<SpriteRenderer>().sprite)
            {
                this.hpGauge2.GetComponent<Image>().fillAmount -= Damage * Attacktimes;
            }
            if (player.GetComponent<SpriteRenderer>().sprite == player3.GetComponent<SpriteRenderer>().sprite)
            {
                this.hpGauge3.GetComponent<Image>().fillAmount -= Damage * Attacktimes;
            }
            if (player.GetComponent<SpriteRenderer>().sprite == player4.GetComponent<SpriteRenderer>().sprite)
            {
                this.hpGauge4.GetComponent<Image>().fillAmount -= Damage * Attacktimes;
            }
        }
        if (player == this.player2)
        {
            if (player.GetComponent<SpriteRenderer>().sprite == player1.GetComponent<SpriteRenderer>().sprite)
            {
                this.hpGauge1.GetComponent<Image>().fillAmount -= Damage * Attacktimes;
            }
            if (player.GetComponent<SpriteRenderer>().sprite == player3.GetComponent<SpriteRenderer>().sprite)
            {
                this.hpGauge3.GetComponent<Image>().fillAmount -= Damage * Attacktimes;
            }
            if (player.GetComponent<SpriteRenderer>().sprite == player4.GetComponent<SpriteRenderer>().sprite)
            {
                this.hpGauge4.GetComponent<Image>().fillAmount -= Damage * Attacktimes;
            }
        }
        if (player == this.player3)
        {
            if (player.GetComponent<SpriteRenderer>().sprite == player1.GetComponent<SpriteRenderer>().sprite)
            {
                this.hpGauge1.GetComponent<Image>().fillAmount -= Damage * Attacktimes;
            }
            if (player.GetComponent<SpriteRenderer>().sprite == player2.GetComponent<SpriteRenderer>().sprite)
            {
                this.hpGauge2.GetComponent<Image>().fillAmount -= Damage * Attacktimes;
            }
            if (player.GetComponent<SpriteRenderer>().sprite == player4.GetComponent<SpriteRenderer>().sprite)
            {
                this.hpGauge4.GetComponent<Image>().fillAmount -= Damage * Attacktimes;
            }
        }
        if (player == this.player4)
        {
            if (player.GetComponent<SpriteRenderer>().sprite == player1.GetComponent<SpriteRenderer>().sprite)
            {
                this.hpGauge1.GetComponent<Image>().fillAmount -= Damage * Attacktimes;
            }
            if (player.GetComponent<SpriteRenderer>().sprite == player2.GetComponent<SpriteRenderer>().sprite)
            {
                this.hpGauge2.GetComponent<Image>().fillAmount -= Damage * Attacktimes;
            }
            if (player.GetComponent<SpriteRenderer>().sprite == player3.GetComponent<SpriteRenderer>().sprite)
            {
                this.hpGauge3.GetComponent<Image>().fillAmount -= Damage * Attacktimes;
            }
        }
        //순위를 정하기 위해 저장
        this.hpGauge[0] = this.hpGauge1.GetComponent<Image>().fillAmount * 100;
        this.hpGauge[1] = this.hpGauge2.GetComponent<Image>().fillAmount * 100;
        this.hpGauge[2] = this.hpGauge3.GetComponent<Image>().fillAmount * 100;
        this.hpGauge[3] = this.hpGauge4.GetComponent<Image>().fillAmount * 100;

    }


    // Update is called once per frame
    void Update () {
        //아무나 체력이 다 떨어지면 게임 종료
        if(this.hpGauge1.GetComponent<Image>().fillAmount==0.0f)
        {
            this.GameEnd = true;
        }
        if(this.hpGauge2.GetComponent<Image>().fillAmount==0.0f)
        {
            this.GameEnd = true;
        }
        if (this.hpGauge3.GetComponent<Image>().fillAmount == 0.0f)
        {
            this.GameEnd = true;
        }
        if (this.hpGauge4.GetComponent<Image>().fillAmount == 0.0f)
        {
            this.GameEnd = true;
        }
        if (GameEnd == true)
        {
            //남은 체력에 따라 등수 정하기
            if (RankCheck == false)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = i; j < 4; j++)
                    {
                        if (hpGauge[i] < hpGauge[j])
                        {
                            float Ftemp = hpGauge[i];
                            hpGauge[i] = hpGauge[j];
                            hpGauge[j] = Ftemp;

                            GameObject Gtemp = Rank[i];
                            Rank[i] = Rank[j];
                            Rank[j] = Gtemp;
                        }
                    }
                }
                RankCheck = true;
            }
            else
            {
                this.delta += Time.deltaTime;
                Timer.GetComponent<Text>().text = "게임 종료!!";
                //결과화면으로 이동
                if (this.delta > this.delay * 1.5f)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        this.Data.GetComponent<Data>().hpGauge[i] = this.hpGauge[i];
                        this.Data.GetComponent<Data>().Name[i] = this.Rank[i].name;
                    }
                    SceneManager.LoadScene("ResultScene");
                    DontDestroyOnLoad(Data);
                }
            }

        }
        
    }
}
