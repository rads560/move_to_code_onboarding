using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class tab4 : MonoBehaviour
{
    GameObject tab4_blocks;

    private void Awake()
    {
        tab4_blocks = GetComponentInChildren<TabToggleParent>().gameObject;
    }

    public void ShowTab()
    {
        tab4_blocks.SetActive(true);
    }

    public void HideTab()
    {
        tab4_blocks.SetActive(false);
    }
}