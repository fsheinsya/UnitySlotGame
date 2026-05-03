using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReelGenerator1 : MonoBehaviour
{
    public GameObject[] imgobj; // 絵柄のプレハブを格納(計7種）
    GameObject[] tmp_obj = new GameObject[90]; // リールの配列
    Transform[] img_pos = new Transform[90]; // 絵柄の位置格納用

    Transform pos; // リールのTransform参照

    // 出現確率しきい値
    int div0 = 7;   // Jackpot
    int div1 = 15;  // 777
    int div2 = 20;  // BAR
    int div3 = 40;  // 宝石
    int div4 = 55;  // スイカ
    int div5 = 80;  // ベル
    // それ以外はチェリー

    void Awake()
    {
        GenerateReel(); // ゲーム開始時に生成
    }

    public void GenerateReel()
    {
        pos = GetComponent<Transform>();

        for (int i = 0; i < 90; i++)
        {
            Vector3 localPos = new Vector3(0.0f, 102.4f * i, 0.0f);
            int tmp;
            int rand = Random.Range(0, 91);

            if (rand < div0)
                tmp = 0;
            else if (rand < div1)
                tmp = 1;
            else if (rand < div2)
                tmp = 2;
            else if (rand < div3)
                tmp = 3;
            else if (rand < div4)
                tmp = 4;
            else if (rand < div5)
                tmp = 5;
            else
                tmp = 6;

            // 絵柄を生成
            tmp_obj[i] = Instantiate(imgobj[tmp]);
            tmp_obj[i].transform.SetParent(transform, false);
            img_pos[i] = tmp_obj[i].GetComponent<Transform>();
            img_pos[i].localPosition = localPos; // 絵柄の配置
        }
    }

    public void DestroyReel()
    {
        GameObject[] reels = GameObject.FindGameObjectsWithTag("reel");
        foreach (GameObject i in reels)
        {
            Destroy(i);
        }
    }
}