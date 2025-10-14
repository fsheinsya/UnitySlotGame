using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button1 : MonoBehaviour
{
    private Image img;
    public ReelController reelcontroller;//reelcontrollerの使用

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        reelcontroller = GameObject.Find("ReelController").GetComponent<ReelController>();//reelcontrollerの取得
    }
    public void OnClick()
    {
        reelcontroller.stopReel();//リールを止める関数を実
        
        img.sprite = Resources.Load<Sprite>("image/pushed_button"); //押したときにUIの変更
    }
}