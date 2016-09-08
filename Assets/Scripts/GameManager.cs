using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    static public int gameScore;
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Init();
            }
            return instance;
        }
    }

    static void Init()
    {
        if (instance == null)
        {
            instance = FindObjectOfType(typeof(GameManager)) as GameManager;
        }
    }

    void Awake()
    {
        Init();
    }

    public static void IncrementScore()
    {
        gameScore += 5;
    }
}
