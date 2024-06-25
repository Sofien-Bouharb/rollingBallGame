using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManagerScript : MonoBehaviour
{
  public AudioSource musicSource;
  public AudioSource sfxSource;


  public AudioClip background;
  public AudioClip gameOver;
  public AudioClip collision;
  public AudioClip pickCoin;
  public AudioClip roll;
  public AudioClip decreaseHp;
  public AudioClip death;
  public AudioClip powerUp;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void SFXplay(AudioClip ac)
    {
        sfxSource.PlayOneShot(ac);
    }

    public void musicStop()
    {
        musicSource.Stop();
    }

    public void sfxStop()
    {
        sfxSource.Stop();
    }
}
