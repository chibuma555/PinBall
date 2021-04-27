using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{ 
    // スコアを計算するための変数を定義
    private int score = 0;

    // テキスト表示のための変数を定義
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // スコアの初期化
        score = 0;

        SetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        //Tag別に衝突した時の得点を加算
        string BallTag = other.gameObject.tag;

        if (BallTag == "SmallStarTag")
        {
            this.score += 50;
        }
        else if (BallTag == "LargeStarTag")
        {
            this.score += 100;
        }
        else if (BallTag == "SmallCloudTag" || BallTag == "LargeCloudTag")
        {
            this.score += 200;
        }

        SetScore();
    }

    void SetScore()
    {
        // スコアテキストの表示
        scoreText.text = string.Format("SCORE:{0}", score);
    }

}

    


