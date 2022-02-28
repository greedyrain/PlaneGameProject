using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public E_FirePos e_FirePos = E_FirePos.TopLeft;
    public float time = 0;

    private void Start()
    {

    }

    void Update()
    {
        time += Time.deltaTime;
        DataManager.Instance.gameTime = (int)time;
        GamePanel.Instance.timeLabel.text = ((int)time).ToString();
    }
}
