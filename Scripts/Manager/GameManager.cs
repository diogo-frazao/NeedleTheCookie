using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

   private const string CookieColliderTag = "CookieCollider";

    public void Awake()
    {
        SingletonPattern();
    }

    private void SingletonPattern()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Getters and Setters.
    public string GetCookieColliderTag()
    {
        return CookieColliderTag;
    }
}
