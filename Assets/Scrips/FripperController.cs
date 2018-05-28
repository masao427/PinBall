using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;

    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start () {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }
	
	// Update is called once per frame
	void Update() {
      
        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        // 発展課題向け
        for (int i = 0; i < Input.touchCount; i++)
        {
            // タッチされたポジション(画面の右か左か)を検出する。
            if (Input.touches[i].position.x < (Screen.width/2))
            {
                // 左のフリッパーを動かす
                if ((Input.touches[i].phase == TouchPhase.Began) && (tag == "LeftFripperTag"))
                {
                    // スクリーンにタッチされたのでフリッパーを動かす。
                    SetAngle(this.flickAngle);
                }
                else if ((Input.touches[i].phase == TouchPhase.Ended) && (tag == "LeftFripperTag"))
                {
                    // タッチが終了したのでフリッパーを元に戻す。
                    SetAngle(this.defaultAngle);
                }
            }
            else
            {
                // 右のフリッパーを動かす
                if ((Input.touches[i].phase == TouchPhase.Began) && (tag == "RightFripperTag"))
                {
                    // スクリーンにタッチされたのでフリッパーを動かす。
                    SetAngle(this.flickAngle);
                }
                else if ((Input.touches[i].phase == TouchPhase.Ended) && (tag == "RightFripperTag"))
                {
                    // タッチが終了したのでフリッパーを元に戻す。
                    SetAngle(this.defaultAngle);
                }
            }
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
