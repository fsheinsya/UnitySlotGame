using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3 : MonoBehaviour
{
    public Reelcontroller reelcontroller;//reelcontrollerの使用

    // Start is called before the first frame update
    void Start()
    {
        reelcontroller = GameObject.Find("ReelController").GetComponent<Reelcontroller>();//reelcontrollerの取得
    }
    public void OnClick()
    {
        reelcontroller.stopReel3();//リールを止める関数を実行

    }
}