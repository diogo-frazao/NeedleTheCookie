using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private float tweenTimeOpen = 0.5f;
    private float tweenTimeClose = 0.35f;

   [SerializeField] private GameObject skinsMenu;
   [SerializeField] private GameObject storeMenu;

    void Start()
    {
        TweenMenu();
        OpenSkins();
        CloseSkins();
        OpenStore();
        CloseStore();
    }

    public void TweenMenu()
    {
       
       gameObject.transform.localPosition = new Vector2(0, -Screen.height * 2);
       gameObject.transform.LeanMoveLocalY(0, tweenTimeOpen).setEaseOutExpo().delay = 0.5f;
        
    }

    public void OpenSkins()
    {
        skinsMenu.transform.localPosition = new Vector2(-Screen.width * 2, 0);
        skinsMenu.transform.LeanMoveLocalX(0, tweenTimeOpen).setEaseOutExpo().delay = 3f;//remove delays
    }

    public void CloseSkins()
    {
        skinsMenu.transform.LeanMoveLocalX(-Screen.width * 2, tweenTimeClose).setEaseOutExpo().delay = 5f;//remove delays
    }

     public void OpenStore()
    {
       storeMenu.transform.localPosition = new Vector2(0, Screen.height*2f);
        storeMenu.transform.LeanMoveLocalY(0, tweenTimeOpen).setEaseOutExpo().delay = 7f;//remove delays
    }

    public void CloseStore()
    {
       storeMenu.transform.LeanMoveLocalY(Screen.height*2f, tweenTimeClose).setEaseOutExpo().delay = 9f;//remove delays
    }
}
