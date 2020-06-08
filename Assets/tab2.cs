using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class tab2 : MonoBehaviour
{
    GameObject tab2_blocks;

    private void Awake()
    {
        tab2_blocks = GetComponentInChildren<TabToggleParent>().gameObject;
    }

    public void ShowTab()
    {
        tab2_blocks.SetActive(true);
    }

    public void HideTab()
    {
        tab2_blocks.SetActive(false);
    }
}
