using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float currentLoud;
    public float MaxLoudness = 10;
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        _slider.value = MaxLoudness;
    }
    
    public void ChangeMaxLoudness()
    {
        MaxLoudness = _slider.value;
    }

    public void SceneChange()
    {
        SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.ButtonClick);
        SceneManager.LoadScene("MainMap");
    }
}
