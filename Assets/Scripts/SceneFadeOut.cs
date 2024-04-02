using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class SceneFadeOut : MonoBehaviour
{
    public float animTime = 2f;         // Fade �ִϸ��̼� ��� �ð� (����:��).  

    private Image fadeImage;            // UGUI�� Image������Ʈ ���� ����.  

    private float start = 0f;           // Mathf.Lerp �޼ҵ��� ù��° ��.  
    private float end = 1f;             // Mathf.Lerp �޼ҵ��� �ι�° ��.  
    private float time = 0f;            // Mathf.Lerp �޼ҵ��� �ð� ��.  

    void Awake()
    {
        // Image ������Ʈ�� �˻��ؼ� ���� ���� �� ����.  
        fadeImage = GetComponent<Image>();
    }

    void Update()
    {
        // Fade �ִϸ��̼� ���.  
        PlayFadeOut();
    }

    // Fade �ִϸ��̼� �Լ�.  
    void PlayFadeOut()
    {
        // ��� �ð� ���.  
        // 2��(animTime)���� ����� �� �ֵ��� animTime���� ������.  
        time += Time.deltaTime / animTime;

        // Image ������Ʈ�� ���� �� �о����.  
        Color color = fadeImage.color;
        // ���� �� ���.  
        color.a = Mathf.Lerp(start, end, time);
        // ����� ���� �� �ٽ� ����.  
        fadeImage.color = color;
    }
}
