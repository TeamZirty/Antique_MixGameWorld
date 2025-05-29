using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("BGM")]
    public AudioSource bgmSource;

    [Header("SFX")]
    public AudioSource sfxSource;
    public AudioClip clickClip;
    public AudioClip buttonClip;
    public AudioClip gameOverClip;
    public AudioClip leafHitClip;

    [Header("Fan SFX")]
    public AudioClip fanClip;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM()
    {
        if (!bgmSource.isPlaying)
        {
            bgmSource.loop = true;   // 혹시라도 코드에서 강제 세팅
            bgmSource.Play();
        }
    }


    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public void RestartBGM()
    {
        bgmSource.Stop();
        bgmSource.Play();
    }

    public void PlaySFX(AudioClip clip, float volume)
    {
        sfxSource.PlayOneShot(clip, volume);
    }

    public void PlayFanSoundAtPosition(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(fanClip, position);
    }
}
