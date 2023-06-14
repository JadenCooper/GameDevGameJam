using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> fireBallLocations = new List<GameObject>();

    private float fuseTime = 0.2f;

    private void Start() 
    {
        foreach (GameObject fireBalls in fireBallLocations)
        {
            fireBalls.SetActive(false);
        }
    }
    
    public void StartFuze()
    {
        StartCoroutine(Suicide());
    }

    private void Shrapnel() 
    {
        Debug.Log(gameObject.name);
        if(gameObject.name != gameObject.name)
        {
            Debug.Log("boom");
        }
    }

    IEnumerator Suicide()
    {
        yield return new WaitForSeconds(fuseTime);

        Shrapnel();
        Destroy(gameObject);
    }
}
