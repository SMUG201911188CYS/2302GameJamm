using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroButton : MonoBehaviour
{

    public void start_btn()
    {
        StartCoroutine(IntroCoroutine(true));
    }

    IEnumerator IntroCoroutine(bool isStart)
    {
        if (isStart)
        {
            SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.ButtonClick);
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.ButtonClick);
            yield return new WaitForSeconds(1f);
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
    public void quit_btn()
    {
        StartCoroutine(IntroCoroutine(false));
    }
}
