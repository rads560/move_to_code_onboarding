using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class tab1 : MonoBehaviour
{
    GameObject tab1_blocks;

    private void Awake()
    {
        tab1_blocks = GetComponentInChildren<TabToggleParent>().gameObject;
    }

    public void ShowTab()
    {
        tab1_blocks.SetActive(true);
    }

    public void HideTab()
    {
        tab1_blocks.SetActive(false);
    }
}
