using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : BasePanel<GameOverPanel>
{
    public UIInput inputLabel;
    public UILabel timeLabel;
    public UIButton btnSubmit;
    public override void Init()
    {
        btnSubmit.onClick.Add(new EventDelegate(() =>
        {
            //将inputLabel的信息存储，同时记录游戏时间，存储到RankData中；
            DataManager.Instance.UpdateRankList(DataManager.Instance.gameTime, inputLabel.value);
            XMLDataManager.Instance.SaveData(DataManager.Instance.RankInfo, "RankInfo");
            Time.timeScale = 1;
            SceneManager.LoadScene("BeginScene");
        }));
        HideMe();
    }

    public override void ShowMe()
    {
        base.ShowMe();
        Time.timeScale = 0;
        timeLabel.text = DataManager.Instance.gameTime.ToString();//每次打开该面板，则直接更改面板上显示的时间；
    }
}
