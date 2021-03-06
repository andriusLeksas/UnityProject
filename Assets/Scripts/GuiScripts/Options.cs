using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer audioMixer;

    public void SetEffectsVolume(float volume)
    {
        audioMixer.SetFloat("Effects", volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("Music", volume);
        audioMixer.SetFloat("Bass", volume);    
    }
}
