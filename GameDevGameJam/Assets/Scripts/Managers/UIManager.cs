using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject EscapeGate;
    public GameObject EscapeArrow;
    public GameObject EscapeWarning;
    public void EscapeTheTomb(int WavesComplete)
    {
        EscapeGate.SetActive(false);
        EscapeArrow.SetActive(true);
        EscapeWarning.SetActive(true);
        StartCoroutine(WarningCloser());
    }

    public void DeclinedEscape()
    {
        EscapeGate.SetActive(true);
        EscapeArrow.SetActive(false);
        EscapeWarning.SetActive(false);
    }

    private IEnumerator WarningCloser()
    {
        yield return new WaitForSeconds(3);
        EscapeWarning.SetActive(false);
    }
}
