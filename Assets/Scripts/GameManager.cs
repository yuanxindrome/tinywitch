using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject player;

    // To make sure GameManager exist at any time and will not destroy itself.
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }




}
