using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public enum SoundType
    {
        EXPLOTION,
        SHOT,
        MUSIC
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] protected AudioClip[] soundList;
    public AudioSource source;
    public void PlaySound(SoundType sound, float volume=1)
    {
        source.PlayOneShot(soundList[(int)sound], volume);
    }
    public void PlayMusic(SoundType sound, float volume = 1)
    {
        source.PlayOneShot(soundList[(int)sound], volume);
    }
    private void Awake()
    {
        if(Instance== null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        PlayMusic(SoundType.MUSIC);
    }
}
