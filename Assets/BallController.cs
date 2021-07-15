using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールを見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    //UIであるB_Textのテキスト欄をC_textと定義
    public Text C_text;

    //スコアの初期値0
    public int score = 0;

    //Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        // UIであるB_Textを探し、そのテキスト欄であるC_textコンポーネントを取得する
        this.C_text = GameObject.Find("B_Text").GetComponent<Text>();

        // UIであるB_TextのCテキスト欄について、スコアをint型をstring型に変換して表示
        C_text.text = score.ToString() + " 点"; 

    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }
    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")
        {
            //スコアを10追加
            score += 10;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            //スコアを20追加
            score += 20;
        }
        else if (other.gameObject.tag == "SmallCloudTag" || other.gameObject.tag == "LargeCloudTag")
        {
            //スコアを30追加
            score += 30;
        }
        // UIであるB_TextのCテキスト欄について、スコアをint型をstring型に変換して表示
        C_text.text = score.ToString() + " 点";
    }
}