using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    CharacterStats characterStats;

    [SerializeField]
    private GameObject shrap;

    [SerializeField]
    private Vector2[] fireDirections = new Vector2[4];

    [SerializeField]
    private float fuseTime = 0.2f;
    
    public GameObject fireBall;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        characterStats = GetComponent<CharacterStats>();
    }

    public void StartFuze()
    {
        StartCoroutine(Suicide());
    }

    public void Shrapnel() 
    {
        int[] directions;
        GameObject sh = Instantiate(shrap);

        sh.transform.localPosition = Vector3.zero;
        sh.transform.position = transform.position;

        List<Transform> fireBallLocations = new List<Transform>();

        for(int i=0;i < sh.transform.childCount; i++)
        {
            Transform child = sh.transform.GetChild(i);
            fireBallLocations.Add(child);
        }

        if(fireDirections.Length == 8)
        {
            directions = new int[] { 90, -90, 0, 180, 130, 50, -50, -130 };
        }
        else
        {
            directions = new int[] { 90, -90, 0, 180 };
        }

        for(int i = 0; i < directions.Length; i++)
        {
            GameObject newFireBall = Instantiate(fireBall, fireBallLocations[i]);

            newFireBall.layer = gameObject.layer;
            newFireBall.GetComponent<Bullet>().Initialize(
                    characterStats.damage.GetValue(), 
                    characterStats.bulletSpeed.GetValue(), 
                    characterStats.range.GetValue(), 
                    fireDirections[i]
                );
        }
    }

    IEnumerator Suicide()
    {
        yield return new WaitForSeconds(fuseTime);

        Shrapnel();
        Destroy(gameObject);
    }

    public void PlayWheelSounds()
    {
        audioSource.Play();
    }
}
