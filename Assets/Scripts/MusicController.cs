using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource _MusicSource;

    public AudioClip MainMusic;
    public AudioClip CutClip;
    public AudioClip DeathClip;

    public void SetMusic(AudioClip clip)
    {
        _MusicSource.clip = clip;
        _MusicSource.loop = true;
        _MusicSource.Play();
    }

    public void PlayGameMusic()
    {
        SetMusic(MainMusic);
    }
    public void StopGameMusic()
    {
        _MusicSource.Stop();
    }

    public void CreateAudioObject(AudioClip clip)
    {
        GameObject obj = new GameObject();

        obj.name = "CLIP: " + clip.name;

        AudioSource _s = obj.AddComponent<AudioSource>();
        _s.clip = clip;
        _s.Play();
        Destroy(obj, clip.length);
    }

    public void PlayTargetCut()
    {
        CreateAudioObject(CutClip);
    }
    public void PlayDeathClip()
    {
        _MusicSource.Stop();
        CreateAudioObject(DeathClip);
    }
}
