﻿using UnityEngine;
using System.Collections;

public class SoundSpectrum : MonoBehaviour
{
    AudioSource _audio;
    float[] spectrum = new float[64];

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        _audio.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
        int i = 1;
        while (i < spectrum.Length - 1)
        {
          
            Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.yellow);
            i++;
        }
    }
}
