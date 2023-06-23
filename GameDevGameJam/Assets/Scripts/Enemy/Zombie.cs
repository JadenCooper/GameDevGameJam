using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(MoanTimer(Random.Range(0.1f, 20f)));
    }
    IEnumerator MoanTimer(float Timer)
    {
        yield return new WaitForSeconds(Timer);
        audioSource.Play();
    }
}