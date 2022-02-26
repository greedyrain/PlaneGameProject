using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time = 0;

    void Update()
    {
        time += Time.deltaTime;
        DataManager.Instance.gameTime = (int)time;
        GamePanel.Instance.timeLabel.text = ((int)time).ToString();
    }
}
