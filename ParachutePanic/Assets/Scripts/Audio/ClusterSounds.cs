using System;
using UnityEngine;

public class ClusterSounds : MonoBehaviour
{
    private SoundFXHandler soundFXHandler;
    [SerializeField] private AudioClip clusterSound;

    private void Start()
    {
        soundFXHandler = SoundFXHandler.instance;
    }

    public void DamageSound()
    {
        soundFXHandler.PlaySoundFXClip(clusterSound, transform, 1f);
    }
}
