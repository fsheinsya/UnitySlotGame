using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelController : MonoBehaviour
{
    public GameObject Reel;
    public GameObject Reel2;
    public GameObject Reel3;

    Vector3 initialpos;
    Vector3 initialpos2;
    Vector3 initialpos3;

    float speed1;
    float speed2;
    float speed3;

    bool stopflag1 = false;
    bool stopflag2 = false;
    bool stopflag3 = false;

    ReelGenerator1 reelGenerator1;
    ReelGenerator1 reelGenerator2;
    ReelGenerator1 reelGenerator3;

    private void Awake()
    {
        initialpos = this.Reel.transform.position;
        initialpos2 = this.Reel2.transform.position;
        initialpos3 = this.Reel3.transform.position;

        reelGenerator1 = GameObject.Find("ReelGenerator1").GetComponent<ReelGenerator1>();
        reelGenerator2 = GameObject.Find("ReelGenerator2").GetComponent<ReelGenerator1>();
        reelGenerator3 = GameObject.Find("ReelGenerator3").GetComponent<ReelGenerator1>();
    }

    public void StartReel()
    {
        reelGenerator1.GenerateReel();
        reelGenerator2.GenerateReel();
        reelGenerator3.GenerateReel();

        speed1 = -600f;
        speed2 = -600f;
        speed3 = -600f;

        stopflag1 = false;
        stopflag2 = false;
        stopflag3 = false;
    }

    public void Update()
    {
        if (Reel == null || Reel2 == null || Reel3 == null) return;
        
        Reel.transform.Translate(0, speed1, 0);
        Reel2.transform.Translate(0, speed2, 0);
        Reel3.transform.Translate(0, speed3, 0);

        if (Reel.transform.position.y < -9000.0f)
            Reel.transform.position = initialpos;

        if (Reel2.transform.position.y < -9000.0f)
            Reel2.transform.position = initialpos2;

        if (Reel3.transform.position.y < -9000.0f)
            Reel3.transform.position = initialpos3;

        if (stopflag1 && 0.87f <= Mathf.Abs(Reel.transform.position.y % 102.4f) / 102.4f &&
            Mathf.Abs(Reel.transform.position.y % 102.4f) / 102.4f < 0.88f)
        {
            speed1 = 0;
        }

        if (stopflag2 && 0.87f <= Mathf.Abs(Reel2.transform.position.y % 102.4f) / 102.4f &&
            Mathf.Abs(Reel2.transform.position.y % 102.4f) / 102.4f < 0.88f)
        {
            speed2 = 0;
        }

        if (stopflag3 && 0.87f <= Mathf.Abs(Reel3.transform.position.y % 102.4f) / 102.4f &&
            Mathf.Abs(Reel3.transform.position.y % 102.4f) / 102.4f < 0.88f)
        {
            speed3 = 0;
        }
    }

    public void stopReel()
    {
        if (!stopflag1) speed1 = -75f;
        stopflag1 = true;
    }

    public void stopReel2()
    {
        if (!stopflag2) speed2 = -75f;
        stopflag2 = true;
    }

    public void stopReel3()
    {
        if (!stopflag3) speed3 = -75f;
        stopflag3 = true;
    }
}
