using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Sprite ASprite; //A,B,C,D 손 모양 그림
    public Sprite BSprite;
    public Sprite CSprite;
    public Sprite DSprite;
    SpriteRenderer m_SpriteRenderer;
	void Start () {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }
	
    public void AButtonDown()//버튼 누를시 손모양 변경
    {
        m_SpriteRenderer.sprite = ASprite;
    }
    public void BButtonDown()
    {
        m_SpriteRenderer.sprite = BSprite;
    }
    public void CButtonDown()
    {
        m_SpriteRenderer.sprite = CSprite;
    }
    public void DButtonDown()
    {
        m_SpriteRenderer.sprite = DSprite;
    }

    void Update () {

	}
}
