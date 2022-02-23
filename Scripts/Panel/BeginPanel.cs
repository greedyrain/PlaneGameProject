using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginPanel : BasePanel<BeginPanel>
{
    public UIButton btnStart,btnRank,btnSetting,btnQuit;
    AudioSource audioSource;
    public override void Init()
    {
        #region 控件绑定事件
        btnStart.onClick.Add(new EventDelegate(()=>
        {
            //打开ChoosePanel，关闭自身；
            ChoosePanel.Instance.ShowMe();
            HideMe();
        }));
        btnRank.onClick.Add(new EventDelegate(() =>
        {
            //打开RankPanel
            RankPanel.Instance.ShowMe();
        }));
        btnSetting.onClick.Add(new EventDelegate(() =>
        {
            //打开SettingPanel
            SettingPanel.Instance.ShowMe();
        }));
        btnQuit.onClick.Add(new EventDelegate(() =>
        {
            //退出游戏；
            Application.Quit();
        }));
        #endregion
    }
}
