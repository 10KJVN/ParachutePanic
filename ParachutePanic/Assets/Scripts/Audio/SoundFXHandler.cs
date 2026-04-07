using System;
using UnityEngine;

public class SoundFXHandler : MonoBehaviour
{
    public static SoundFXHandler instance;

    [SerializeField] private AudioSource soundFXobject;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    
    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        var audioSource = Instantiate(soundFXobject, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();
        
        var clipLength = audioSource.clip.length;
        
        Destroy(audioSource.gameObject, clipLength);
    }
}
