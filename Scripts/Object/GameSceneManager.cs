using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public float time = 0;

    private void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            FirePos firePos = Instantiate(Resources.Load<FirePos>("FirePos"));
            firePos.transform.localPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * i / 2, 0, Screen.height * i / 2));
            firePos.transform.localRotation *= Quaternion.AngleAxis(90, new Vector3(0,(i/3 * 45)+ (-90 * i / 2), 0));
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        DataManager.Instance.gameTime = (int)time;
        GamePanel.Instance.timeLabel.text = ((int)time).ToString();
    }
}
