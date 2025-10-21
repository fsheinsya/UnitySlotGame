using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Retry : MonoBehaviour
{

    public ReelController reelcontroller;//ReelControllerの宣言
    public ReelGenerator1 reelgenerator; //ReelGenerator1の宣言

    public Button1 btn1;
    public Button2 btn2;
    public Button3 btn3;

    void Start()
    {
        reelcontroller = GameObject.Find("ReelController").GetComponent<ReelController>();//ReelControllerの取得
        reelgenerator = GameObject.Find("ReelGenerator1").GetComponent<ReelGenerator1>();//ReelGenerator1の取得\
    }
    public void OnClick()
    {
        btn1.img.sprite = Resources.Load<Sprite>("image/pushed_button");
        btn2.img.sprite = Resources.Load<Sprite>("image/pushed_button"); 
        btn3.img.sprite = Resources.Load<Sprite>("image/pushed_button"); 
        
        reelgenerator.DestroyReel();//リールを全消しする関数を呼ぶ
        reelcontroller.StartReel();//リールを再生成して回す関数を呼ぶ
    }
}