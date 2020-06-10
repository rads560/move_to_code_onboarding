using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class Tab : MonoBehaviour
{
    TabManager tabManager;
    PressableButtonHoloLens2 tabButton;
    Interactable tabInteractable;

    private void Awake()
    {
        tabButton = GetComponentInParent<PressableButtonHoloLens2>();
        tabInteractable = tabButton.GetComponent<Interactable>();
        tabInteractable.OnClick.AddListener(ShowTab);
        tabManager = tabButton.GetComponentInParent<TabManager>();
        tabManager.SetTab(this);
        HideTab();
    }

    public void ShowTab()
    {
        tabManager.HideActive();
        tabManager.SetTab(this);
        gameObject.SetActive(true);
    }

    public void HideTab()
    {
        gameObject.SetActive(false);
    }
}