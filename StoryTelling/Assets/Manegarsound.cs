using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manegarsound : MonoBehaviour
{


    public Sprite audioOffSprite;
    public Sprite audioOnfSprite;
    public Image Soundimage;

    public AudioSource musicAudioSource;
    public AudioSource soundEffectsAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleMuteMusic()
    {
        if (musicAudioSource.volume == 0)
        {
            musicAudioSource.volume = 1;
            Soundimage.sprite = audioOnfSprite;
        }
        else if (musicAudioSource.volume == 1)
        {
            musicAudioSource.volume = 0;
            Soundimage.sprite = audioOffSprite;
        }
    }

    public void PlaySoundEffect()
    {
        soundEffectsAudioSource.Play();
    }

    public void SoundCont()
    {

        if (soundEffectsAudioSource.volume == 0)
        {

            soundEffectsAudioSource.volume = 1;

        }
        else if (soundEffectsAudioSource.volume == 1)
        {
            soundEffectsAudioSource.volume = 0;

        }
    }
}
