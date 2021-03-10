using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SettingsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer Music;
    public AudioMixer GunFX;
    public void SetMusicVolume (float Volume)
    {
        Music.SetFloat("volumeSettings", Volume);

    }

    public void SetGunVolume(float Volume)
    {
        GunFX.SetFloat("volumeSettings", Volume);

    }
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetVSync (int VsyncIndex)
    {
        QualitySettings.vSyncCount = (VsyncIndex);
    }
}
