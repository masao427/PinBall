using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
    // ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    // スコア
    private int score = 0;

    // スコアテキストオブジェクト
    private GameObject scoreNumber;

    // ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    // Use this for initialization
    void Start ()
    {
        // シーン中のScoreNumberオブジェクトを取得
        this.scoreNumber = GameObject.Find("ScoreNumber");

        // シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
    }
	
	// Update is called once per frame
	void Update () {
        // ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        // スコアを追加
        switch (other.gameObject.tag)
        {
            case "SmallStarTag":
                Debug.Log("Hit to SmallStar: " + score + " + 5");
                this.score += 5;
                break;

            case "LargeStarTag":
                Debug.Log("Hit to LargeStar: " + score + " + 10");
                this.score += 10;
                break;

            case "SmallCloudTag":
                Debug.Log("Hit to SmallCloud: " + score + " + 15");
                this.score += 15;
                break;

            case "LargeCloudTag":
                Debug.Log("Hit to LargeCloud: " + score + " + 20");
                this.score += 20;
                break;

            default:
                break;
        }

        // スコアを表示
        this.scoreNumber.GetComponent<Text>().text = "Score "+ this.score.ToString();
    }
}
