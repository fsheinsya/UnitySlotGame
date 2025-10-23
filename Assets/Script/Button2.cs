using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button2 : MonoBehaviour
{
    public Image img;
    public ReelController reelcontroller;//reelcontrollerの使用
    public AudioClip buttonSound2;
    private AudioSource audioSource; 

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
        reelcontroller = GameObject.Find("ReelController").GetComponent<ReelController>();//reelcontrollerの取得
    }
    public void OnClick()
    {
        reelcontroller.stopReel2();
        img.sprite = Resources.Load<Sprite>("image/button");
        audioSource.PlayOneShot(buttonSound2);
    }
}