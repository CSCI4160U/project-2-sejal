using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private static bool isMenuMusicPlaying = false;

    void Awake()
    {
        if (!isMenuMusicPlaying)
        {
            DontDestroyOnLoad(gameObject);
            isMenuMusicPlaying = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
