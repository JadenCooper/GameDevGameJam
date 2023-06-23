using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class MoneyGrubber : MonoBehaviour
{
     // https://discussions.unity.com/t/how-to-make-a-timer-that-counts-up-in-seconds-as-an-int/147546/2
    // https://discussions.unity.com/t/how-to-make-a-character-zig-zag-while-moving-towards-a-moving-player/96238/3

    public KnockBack knockback;
    public UnityEvent stopMovement;
    public GameObject imagePrefab;
    public GameObject coinPrefab;
    private GameObject spawnedImage;

    private AudioSource audioSource;
    private CharacterStats characterStats;
    private bool isRunningAway = false;
    private Vector3 position;

    void Start()
    {
        characterStats = GetComponent<CharacterStats>();
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void StealMoney()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerPos = player.gameObject.transform.position;

        if(gameObject.GetComponent<CharacterStats>() == null)
        {
            Debug.Log(gameObject.name + " does not have the character script on it");
        }

        if (player == null)
        {
            Debug.Log(gameObject.name + " does not have the character script on it");
            return;
        }

        knockback.Knock(playerPos, player);

        TMP_Text moneyText = GameObject.Find("MoneyCount").GetComponent<TMP_Text>();
        int currentCoins = ItemManager.instance.coins;
        currentCoins -= 100;
        string moneyCounterText = "Coins: " + currentCoins;
        moneyText.text = moneyCounterText;

        StartRunningAway();
    }

    public void DropMoney()
    {
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
        Destroy(spawnedImage);
    }

    private void StartRunningAway()
    {
        if (!isRunningAway)
        {
            StartCoroutine(Timer());
            isRunningAway = true;
        }
    }

    private void RunAway()
    {
        float speed = 12f;
        stopMovement?.Invoke();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = transform.position - player.transform.position;
        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime;
    }

    IEnumerator Timer()
    {
        float elapsedTime = 0;

        while (elapsedTime < 10f)
        {
            RunAway();
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isRunningAway = false;
        StartCoroutine(Portal());
    }


    IEnumerator Portal()
    {
        stopMovement?.Invoke();
        spawnedImage = Instantiate(imagePrefab, transform.position, Quaternion.identity);
        stopMovement?.Invoke();
        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
        Destroy(spawnedImage);
    }
}