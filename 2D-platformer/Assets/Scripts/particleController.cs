using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleController : MonoBehaviour
{
    public static particleController instance;
    [SerializeField] private GameObject rainEffect;
    public bool startRain = false;

    private void Awake()
    {
        //Makeing script singeleton
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

    private void Start()
    {
        if(startRain == true)
        {
            rainEffect.SetActive(true);
        }
    }

    public void startRaining(bool startRain)
    {
        if(startRain == true)
        {
           rainEffect.SetActive(true);
        }
        else
        {
            rainEffect.SetActive(false);
        }
    }

}
