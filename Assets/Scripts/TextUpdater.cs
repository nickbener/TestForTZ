using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TextUpdater : MonoBehaviour
{
    public int enCount;

    public int minCount;
    public int maxCount;
    
    public Text enemyText;
    public GameObject win;

    private void Start()
    {
        enCount = Random.Range(minCount, maxCount);
    }

    void Update()
    {
        enemyText.text = "Enemy: " + enCount.ToString();
        if (enCount <= 0)
        {
            win.SetActive(true);
        }
    }
}