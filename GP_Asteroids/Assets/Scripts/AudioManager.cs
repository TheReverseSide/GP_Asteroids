using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private static AudioManager instance = null;

    public static AudioManager Instance
    {
        get { return instance; }
    }

    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;
    
    void Awake()
    {
        #region Singleton

        if (instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        #endregion
    }

    public void PlaySFX(AudioClip clip, float volume = 1.0f)
    {
        if (!sfxSource.isPlaying)
        {
            sfxSource.clip = clip;
            sfxSource.volume = volume;
            sfxSource.Play();
        }
        // else
        // {
        //     PlayDynamicSound(clip, volume);
        // }
    }

    public void StopSound()
    {
        sfxSource.Stop();
    }

    public void PlayMusic(AudioClip clip, float volume = 1.0f)
    {
        if (musicSource.isPlaying && musicSource.clip == clip)
        {
            return;
        }

        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.volume = volume;
        musicSource.Play();
    }

    private void PlayDynamicSound(AudioClip clip, float volume = 1.0f)
    {
        GameObject sfxGO = new GameObject("Dynamic_" + clip.name);
        sfxGO.transform.SetParent(transform);

        AudioSource source = sfxGO.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.Play();
        
        Destroy(sfxGO, clip.length);
    }
}
