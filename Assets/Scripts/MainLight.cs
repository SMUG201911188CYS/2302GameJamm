using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLight : MonoBehaviour
{

    Light _light;

    float minSpeed = 0.1f;
    float maxSpeed = 0.4f;
    float minInstensity = 3.0f;
    float maxIntensity = 5.0f;

    void Start()
    {
        _light = GetComponent<Light>();
        StartCoroutine(run());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator run()
    {
        while(true)
        {
            _light.enabled = true;
            _light.intensity = Random.Range(minInstensity, maxIntensity);
            yield return new WaitForSeconds(Random.Range(minSpeed, maxSpeed));
            _light.enabled = false;
            yield return new WaitForSeconds(Random.Range(minSpeed, maxSpeed));
        }
    }
}
