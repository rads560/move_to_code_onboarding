using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    private Tab currentTab = null;

    private void Awake()
    {
        currentTab.ShowTab();
    }

    public void SetTab(Tab t)
    {
        currentTab = t;
    }

    public void HideActive()
    {
        currentTab.HideTab();
    }
}