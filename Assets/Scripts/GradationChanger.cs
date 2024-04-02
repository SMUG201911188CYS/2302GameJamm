using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradationChanger : MonoBehaviour
{
    public Gradient gradient;

    [Range(0,5)]
    public float time = 1f; //정해진 시간마다 주기적으로 반복

    private float _gradientWaveTime;
    private float _curXNormalized;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        _gradientWaveTime += Time.deltaTime;

        _curXNormalized = Mathf.PingPong(_gradientWaveTime, time);
        
        _image.color = gradient.Evaluate(_curXNormalized);
    }
}
