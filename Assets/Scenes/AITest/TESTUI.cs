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
            t.text = "�׾����ϴ�!";
        }
        else if (PlayerMove.isScream)
        {
            t.text = "���׽��ϴ�!";
        }
        else if (PlayerMove.isWalk)
        {
            t.text = "�����̴� ��...";
        }
        else
        {
            t.text = "���� ���̴� ��...";
        }

        orange.text = "���� ���� �� : " + PlayerMove._orange.ToString();
    }
}
