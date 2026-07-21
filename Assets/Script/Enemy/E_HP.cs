using UnityEngine;
using UnityEngine.UI;


public class E_HP : MonoBehaviour
{
    public Image imgHP;
    public Sprite imgHPFull;     //緑バー
    public Sprite imgHPHalf;     //緑バー
    public Sprite imgHPDanger;     //緑バー
    public int maxHP;       //最大値
    private int hp;         //HP
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = maxHP;     //初期化
        imgHP.sprite = imgHPFull;
    }

    //ダメージを受けたときに、HPバーが変化
    public void damageHP(int damage)
    {
        hp -= damage;
        imgHP.fillAmount = (float)hp / maxHP;
    }

    void FixedUpdate()
    {
        if(hp <= (maxHP/2))
        {
            imgHP.sprite = imgHPHalf;
        }

        if(hp <= (maxHP/4))
        {
            imgHP.sprite = imgHPDanger;
        }
    }
}
