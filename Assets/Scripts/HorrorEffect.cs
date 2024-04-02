using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorEffect : MonoBehaviour
{
    public AudioClip HorrorSound;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.instance.HorrorEffectSoundPlay(HorrorSound);
            Destroy(gameObject, 1f);
        }
    }
}
