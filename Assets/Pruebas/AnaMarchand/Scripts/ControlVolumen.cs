using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVolumen : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    [SerializeField]
    private float masterVolume = 1.0f;

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = masterVolume;
    }

    public void SetVolume(float vol)
    {
        masterVolume = vol;
    }
}
