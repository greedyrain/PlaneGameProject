using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : BasePanel<GameOverPanel>
{
    public UIInput inputLabel;
    public UIButton btnSubmit;
    public override void Init()
    {
        btnSubmit.onClick.Add(new EventDelegate(() =>
        {
            //将inputLabel的信息存储，同时记录游戏事件，存储到RankData中；
            SceneManager.LoadScene("BeginScene");
        }));
        HideMe();
    }
}
