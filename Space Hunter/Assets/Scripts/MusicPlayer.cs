using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
        
    private void Awake()
    {
        int musicPlayerNum = FindObjectsOfType<MusicPlayer>().Length;
        if (musicPlayerNum>1)
        {
            DestroyObject(gameObject);
        }
       else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
