using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpMenuy : MonoBehaviour
{
    public GameObject helpPanel;
    
    public void ShowHelpPanel()
    {
        helpPanel.SetActive(true);
    }

    public void CloseHelpPanel()
    {
        helpPanel.SetActive(false);
    }
}
