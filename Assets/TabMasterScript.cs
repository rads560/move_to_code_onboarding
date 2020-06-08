using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class TabMasterScript : MonoBehaviour
{
    public tab1 tab_one;
    public tab2 tab_two;
    public tab3 tab_three;
    public tab4 tab_four;

    PressableButtonHoloLens2 button_tab1;
    Interactable interactable_tab1;

    PressableButtonHoloLens2 button_tab2;
    Interactable interactable_tab2;

    PressableButtonHoloLens2 button_tab3;
    Interactable interactable_tab3;

    PressableButtonHoloLens2 button_tab4;
    Interactable interactable_tab4;

    int active;

    private void Awake()
    {
        PressableButtonHoloLens2[] buttons = GetComponentsInChildren<PressableButtonHoloLens2>();
        foreach(var button in buttons)
        {
            if (button.name.Equals("Tab1_Button"))
            {
                button_tab1 = button;
                interactable_tab1 = button_tab1.GetComponent<Interactable>();
                interactable_tab1.OnClick.AddListener(ShowTab1);
            }
            else if (button.name.Equals("Tab2_Button"))
            {
                button_tab2 = button;
                interactable_tab2 = button_tab2.GetComponent<Interactable>();
                interactable_tab2.OnClick.AddListener(ShowTab2);
            }
            else if (button.name.Equals("Tab3_Button"))
            {
                button_tab3 = button;
                interactable_tab3 = button_tab3.GetComponent<Interactable>();
                interactable_tab3.OnClick.AddListener(ShowTab3);
            }
            else if (button.name.Equals("Tab4_Button"))
            {
                button_tab4 = button;
                interactable_tab4 = button_tab4.GetComponent<Interactable>();
                interactable_tab4.OnClick.AddListener(ShowTab4);
            }
        }
        active = 0;
        ShowTab1();
    }

    public void HideActive()
    {
        if(active == 0)
        {
            tab_one.HideTab();
            tab_two.HideTab();
            tab_three.HideTab();
            tab_four.HideTab();
        }
        if(active == 1)
        {
            tab_one.HideTab();
        }
        else if(active == 2)
        {
            tab_two.HideTab();
        }
        else if(active == 3)
        {
            tab_three.HideTab();
        }
        else
        {
            tab_four.HideTab();
        }
    }

    public void ShowTab1()
    {
        HideActive();
        tab_one.ShowTab();
        active = 1;
    }

    public void ShowTab2()
    {
        HideActive();
        tab_two.ShowTab();
        active = 2;
    }

    public void ShowTab3()
    {
        HideActive();
        tab_three.ShowTab();
        active = 3;
    }

    public void ShowTab4()
    {
        HideActive();
        tab_four.ShowTab();
        active = 4;
    }
}