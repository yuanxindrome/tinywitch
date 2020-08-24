using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WaveText : MonoBehaviour
{
    public TextMeshProUGUI titleDisplay;
    public TextMeshProUGUI des;
   
    void Update()
    {
        DesUpdate();
        StageTextUpdate();
    }

    public void StageTextUpdate()
    {
        for (int i = 0; i < WaveSpawner.instance.waves.Length; i++)
        {
            if (WaveSpawner.instance.nextWave == i)
            {
                titleDisplay.text = WaveSpawner.instance.waves[i].name;
            }
        }
    }

    public void DesUpdate()
    {
        for (int i = 0; i < WaveSpawner.instance.waves.Length; i++)
        {
            if (WaveSpawner.instance.nextWave == i)
            {
                des.text = WaveSpawner.instance.waves[i].description;
            }
        }
    }

}
