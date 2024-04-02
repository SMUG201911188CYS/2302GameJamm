using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorEffectDol : MonoBehaviour
{
    public AudioClip HorrorSound;
    public GameObject Dol;
    private bool isOn = false;    // Start is called before the first frame update

    public void Start()
    {
        Dol.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hi");
        if (other.CompareTag("Player") && !isOn)
        {
            isOn = true;
            SoundManager.instance.HorrorEffectSoundPlay(HorrorSound);
            Dol.SetActive(true);
        }
    }
}
