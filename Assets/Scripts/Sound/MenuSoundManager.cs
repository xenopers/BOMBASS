using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuSoundManager : MonoBehaviour
{
    //public Toggle toggleMusic;
   // public Toggle toggleSound;
    public Slider musicSlider;
    public Slider soundSlider;

    public float musicVolume;
    public float soundVolume;

    public AudioSource music;

    public AudioSource[] sound;

    void Start()
    {
        musicVolume = PlayerPrefs.GetFloat("musicVolume", musicVolume);
        soundVolume = PlayerPrefs.GetFloat("soundVolume", soundVolume);
        ValueSound();
        ValueMusic();
    }

    public void ToggleMusic()
    {
        //if (toggleMusic.isOn) musicVolume = 1; else musicVolume = 0;
        ValueMusic();
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
    }

    public void ToggleSound()
    {
        //if (toggleSound.isOn) soundVolume = 1; else soundVolume = 0;
        ValueSound();
        PlayerPrefs.SetFloat("soundVolume", soundVolume);
    }

    public void SliderSound()
    {
        soundVolume = soundSlider.value;
        ValueSound();
        PlayerPrefs.SetFloat("soundVolume", soundVolume);
    }

    public void ValueSound()
    {
        for (int i = 0; i < sound.Length; i++) sound[i].volume = soundVolume;
        soundSlider.value = soundVolume;
        //if (soundVolume == 0) toggleSound.isOn = false; else { toggleSound.isOn = true; }
    }

    public void SliderMusic()
    {
        musicVolume = musicSlider.value;
        ValueMusic();
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
    }

    public void ValueMusic()
    {
        music.volume = musicVolume;
        musicSlider.value = musicVolume;
        //if (musicVolume == 0) toggleMusic.isOn = false; else toggleMusic.isOn = true;
    }
}
