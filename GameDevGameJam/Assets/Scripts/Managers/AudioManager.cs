using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    public static AudioManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AudioManager>();
            }
            return _instance;
        }
    }
    static AudioManager _instance;

    private void Awake()
    {
        _instance = this;
    }
    #endregion

    public AudioSource itemPickup;
    public AudioSource coinPickup;
    public AudioSource doorOpen;
    public AudioSource doorClose;
    // Start is called before the first frame update
    public void ItemPickup()
    {
        itemPickup.Play();
    }

    public void CoinPickup()
    {
        coinPickup.Play();
    }

    public void DoorOpen()
    {
        doorOpen.Play();
    }

    public void DoorClose()
    {
        doorClose.Play();
    }
}
