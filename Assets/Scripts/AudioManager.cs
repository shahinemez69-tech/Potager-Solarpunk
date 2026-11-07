using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; 

    public AudioSource sfxSource; 
    public AudioClip plantClip;
    public AudioClip harvestClip;
    public AudioClip popClip;

    void Awake()
    {
        instance = this;
    }

    public void PlayPlant()   { sfxSource.PlayOneShot(plantClip); }
    public void PlayHarvest() { sfxSource.PlayOneShot(harvestClip); }
    public void PlayPop()     { sfxSource.PlayOneShot(popClip); }
}