using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouches : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    private void Start()
    {
        //HingeJointコンポーネント
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount == 0)
        {
            SetAngle(this.defaultAngle);
        }

        for (int i = 0; i < Input.touchCount; i++)
        {
            // 座標xがスクリーンの２分の１以上の場合
            if (Input.touches[i].position.x <= Screen.width / 2)
            {
                //左矢印キーを押した時左フリッパーを動かす
                if (Input.touches[i].phase == TouchPhase.Began && tag == "LeftFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
            }
            else if (Input.touches[i].position.x >= Screen.width / 2)
            {
                //右矢印キーを押した時右フリッパーを動かす
                if (Input.touches[i].phase == TouchPhase.Began && tag == "RightFripperTag")
                {
                    SetAngle(this.flickAngle);
                }
                //左矢印キー離されたときフリッパーを元に戻す
            }
            if (Input.touches[i].phase == TouchPhase.Ended && tag == "LeftFripperTag")
            {
                SetAngle(this.defaultAngle);
            }
                //右矢印キーを離されたとき右フリッパーを元に戻す
            if (Input.touches[i].phase == TouchPhase.Ended && tag == "RightFripperTag")
            {
                SetAngle(this.defaultAngle);
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
