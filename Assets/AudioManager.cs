using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public enum Sounds
    {
        Jump,
        Die,
        Pass
    }
    
    public AudioClip jumpSfx;
    public AudioClip dieSfx;
    public AudioClip passSfx;
    public AudioSource audioSource;

    void Awake()
    {
        Locator.Instance.player.OnPass += (_) => PlaySound(Sounds.Pass);
        Locator.Instance.player.OnDeath += () => PlaySound(Sounds.Die);
        Locator.Instance.player.OnJump += () => PlaySound(Sounds.Jump);
    }

    public void PlaySound(Sounds sound)
    {
        switch (sound)
        {
            case Sounds.Jump: audioSource.PlayOneShot(jumpSfx); break;
            case Sounds.Die: audioSource.PlayOneShot(dieSfx); break;
            case Sounds.Pass: audioSource.PlayOneShot(passSfx); break;
            default: throw new ArgumentOutOfRangeException(nameof(sound), sound, null);
        }
    }
}
