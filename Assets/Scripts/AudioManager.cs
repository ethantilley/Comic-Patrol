using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> sfx = new List<AudioClip>();

    public AudioClip[] bulletCollsionFX;

    public AudioSource source;


    public static AudioManager instance;

    private void Awake()
    {
        if (instance != this)
        {
            DestroyImmediate(instance);
            instance = this;
        }
        else
        {
            instance = this;
        }
    }

    public void PlayFX()
    {
        int randFX = Random.Range(0, bulletCollsionFX.Length);

        source.PlayOneShot(bulletCollsionFX[randFX]);
    }

    // loops though tthe sound in a list to see if the name matches the name that was passed through the function when called 
    public void PlaySound(string _Sound)
    {

        foreach (var item in sfx)
        {
            if (item.name == _Sound)
            {
                source.PlayOneShot(item);
                return;
            }
        }
        // if no sound found with that name.
        Debug.LogError("Error 404, Sound Not Found");


    }
}
