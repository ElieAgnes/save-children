using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorInterractionUI : MonoBehaviour
{
    [SerializeField] private GameObject uiPanel = null;
    [SerializeField] private TextMeshProUGUI promptText = null;

    public bool isDisplayed;

    void Start()
    {
        uiPanel.SetActive(false);
        isDisplayed = false;
    }

    public void activate(string text)
    {
        uiPanel.SetActive(true);
        promptText.SetText(text);
        isDisplayed = true;
    }

    public void disable()
    {
        uiPanel.SetActive(false);
        isDisplayed = false;
    }
}
