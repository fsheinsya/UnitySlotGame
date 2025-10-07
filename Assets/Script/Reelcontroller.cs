using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reelcontroller : MonoBehaviour
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

    private void Awake()　//ゲーム開始時に
    {
        
        initialpos = this.Reel.transform.position;　//初期位置を取得しておく
        initialpos2 = this.Reel2.transform.position;
        initialpos3 = this.Reel3.transform.position;

        speed1 = -0.35f;　//リールの回転スピードの代入
        speed2 = -0.35f;
        speed3 = -0.35f;
    }
    private void Update()　//ゲームが始まったら
    {
        this.Reel.transform.Translate(0, speed1, 0);　//リールをｙ方向（下）に動かす
        this.Reel2.transform.Translate(0, speed2, 0);
        this.Reel3.transform.Translate(0, speed3, 0);

        if (Reel.transform.position.y < -3.78f)　//リールが一番下に来たら
        {
            this.Reel.transform.position = initialpos;　//初期位置に戻す
        }

        if (Reel2.transform.position.y < -3.78f)
        {
            this.Reel2.transform.position = initialpos2;
        }

        if (Reel3.transform.position.y < -3.78f)
        {
            this.Reel3.transform.position = initialpos3;
        }
    }

    public void stopReel() //この関数がボタン1を押すと呼ばれる
    {
        speed1 = 0;　//リールの回転スピードを０にする
       
    }

    public void stopReel2()
    {
        speed2 = 0;

    }

    public void stopReel3()
    {
        speed3 = 0;

    }
}
