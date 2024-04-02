using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TESTUI : MonoBehaviour
{
    public TMP_Text t ;

    public TMP_Text orange;
    

    private void Update()
    {
        if (PlayerMove.isDead)
        {
            t.text = "죽었습니다!";
        }
        else if (PlayerMove.isScream)
        {
            t.text = "들켰습니다!";
        }
        else if (PlayerMove.isWalk)
        {
            t.text = "움직이는 중...";
        }
        else
        {
            t.text = "숨을 죽이는 중...";
        }

        orange.text = "남은 귤의 수 : " + PlayerMove._orange.ToString();
    }
}
