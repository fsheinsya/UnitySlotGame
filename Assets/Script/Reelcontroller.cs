using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelController : MonoBehaviour
{
    public GameObject Reel; //リールを取得
    public GameObject Reel2;
    public GameObject Reel3;

    Vector3 initialpos; //初期位置
    Vector3 initialpos2;
    Vector3 initialpos3;

    float speed1; //リールの回転速度
    float speed2;
    float speed3;
    
    bool stopflag1 = false;//ボタンが押されたかどうか
    bool stopflag2 = false;
    bool stopflag3 = false;
    
    ReelGenerator1 reelGenerator1;//ReelGenerator1の宣言
    ReelGenerator1 reelGenerator2;
    ReelGenerator1 reelGenerator3;

    private void Awake()　//ゲーム開始時に
    {
        
        initialpos = this.Reel.transform.position;　//初期位置を取得しておく
        initialpos2 = this.Reel2.transform.position;
        initialpos3 = this.Reel3.transform.position;
        
        reelGenerator1 = GameObject.Find("ReelGenerator1").GetComponent<ReelGenerator1>();//ReelGenerator1の取得
        reelGenerator2 = GameObject.Find("ReelGenerator2").GetComponent<ReelGenerator1>();
        reelGenerator3 = GameObject.Find("ReelGenerator3").GetComponent<ReelGenerator1>();
    }
    
    public void StartReel()//リールを再生成して回し始める関数
    {
        reelGenerator1.GenerateReel();//ReelGenerator1のGenerateReel関数を呼ぶ
        reelGenerator2.GenerateReel();
        reelGenerator3.GenerateReel();
        speed1 = -0.35f;　//リールの回転スピードの代入
        speed2 = -0.35f;
        speed3 = -0.35f;
        stopflag1 = false;　//ボタンを押していない状態にリセット
        stopflag2 = false;
        stopflag3 = false;
    }   
    
    private void Update()　//ゲームが始まったら
    {
        this.Reel.transform.Translate(0, speed1, 0);　//リールをｙ方向（下）に動かす
        this.Reel2.transform.Translate(0, speed2, 0);
        this.Reel3.transform.Translate(0, speed3, 0);

        if (Reel.transform.position.y < -400.0f)　//リールが一番下に来たら
        {
            this.Reel.transform.position = initialpos;　//初期位置に戻す
        }

        if (Reel2.transform.position.y < -400.0f)
        {
            this.Reel2.transform.position = initialpos2;
        }

        if (Reel3.transform.position.y < -400.0f)
        {
            this.Reel3.transform.position = initialpos3;
        }
        
        if (stopflag1 && 0.85 <= Mathf.Abs(Reel.transform.position.y % 1.5f) && Mathf.Abs(Reel.transform.position.y % 1.5f) < 0.88)
            //ボタンが押されていて、かつ、リールを1.5ｆで割った余りが規定値以内であったら
        {
            speed1 = 0;//リールの回転スピードを０にする
        }
        if (stopflag2 && 0.85 <= Mathf.Abs(Reel2.transform.position.y % 1.5f) && Mathf.Abs(Reel2.transform.position.y % 1.5f) < 0.88)
        {
            speed2 = 0;
        }
        if (stopflag3 && 0.85 <= Mathf.Abs(Reel3.transform.position.y % 1.5f) && Mathf.Abs(Reel3.transform.position.y % 1.5f) < 0.88)
        {
            speed3 = 0;
        }
    }

    public void stopReel() //この関数がボタン1を押すと呼ばれる
    {
        if (stopflag1 != true)//ボタンがまだ押されてない場合
        {
            speed1 = -0.03f;//リールをゆっくりにする
        }
        stopflag1 = true;　//ボタンを押す
    }
    
    public void stopReel2()
    {
        if (stopflag2 != true)
        {
            speed2 = -0.03f;
        }
        stopflag2 = true;
    }
    
    public void stopReel3()
    {
        if (stopflag3 != true)
        {
            speed3 = -0.03f;
        }
        stopflag3 = true;
    }
}
