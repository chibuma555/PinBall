using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Start is called before the first frame update
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        // Aキーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.A) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        // Dキーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.D) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        // Sキーを押した時両方のフリッパーを動かす
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetAngle(this.flickAngle);
        }

        // Aキーが離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.A) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        // Dキーが離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.D) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        // Sキーが離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.S))
        {
            SetAngle(this.defaultAngle);
        }

        // スマホでのタッチ判定
        if (Input.touchCount > 0)
        {   
            Touch myTouch = Input.GetTouch(0);

            Touch[] myTouches = Input.touches;

            for(int i = 0; i < Input.touchCount; i++)
            { 
                if (Input.touches[i].position.x　< Screen.width / 2)
                {
                    if (myTouch.phase == TouchPhase.Began && tag == "LeftFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }

                    if (myTouch.phase == TouchPhase.Ended && tag == "LeftFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }

                    if (myTouch.phase == TouchPhase.Ended && tag == "RightFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                }
                else if (Input.touches[i].position.x > Screen.width / 2)
                {
                    if (myTouch.phase == TouchPhase.Began && tag == "RightFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }

                    if (myTouch.phase == TouchPhase.Ended && tag == "RightFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }

                    if (myTouch.phase == TouchPhase.Ended && tag == "LeftFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                }
            }
        }
    }

    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
