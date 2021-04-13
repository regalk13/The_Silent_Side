using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settingsmenu2 : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume (float music)   
    {
        audioMixer.SetFloat("music", music);
    }

    }


