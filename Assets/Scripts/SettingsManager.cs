using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    // Not used yet, for the settings

    public GameObject creditsPanel;
    void Start()
    {
        creditsPanel.SetActive(false);
    }

    public void CreditsPanel()
    {
        creditsPanel.SetActive(true);
    }
}
