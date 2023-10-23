using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public static GameManager Instance { get; private set; }


    public float initialGameSpeed = 2f;
    public float gameSpeedIncrease = .1f;
    public float gameSpeed {  get; private set; }



    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else 
        {
            DestroyImmediate(gameObject);
        }
    }


    private void OnDestroy()
    {
        if (Instance == null)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        gameSpeed = initialGameSpeed;
    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;

    }


}
