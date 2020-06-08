using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class tab3 : MonoBehaviour
{
    GameObject tab3_blocks;

    private void Awake()
    {
        tab3_blocks = GetComponentInChildren<TabToggleParent>().gameObject;
    }

    public void ShowTab()
    {
        tab3_blocks.SetActive(true);
    }

    public void HideTab()
    {
        tab3_blocks.SetActive(false);
    }
}