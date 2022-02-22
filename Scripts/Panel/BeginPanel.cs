using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginPanel : BasePanel<BeginPanel>
{
    public UIButton btnStart,btnRank,btnSetting,btnQuit;
    public override void Init()
    {
        #region 按钮绑定代码
        btnStart.onClick.Add(new EventDelegate(()=>
        {
            //切换到GameScene
        }));
        btnRank.onClick.Add(new EventDelegate(() =>
        {
            //打开RankPanel
        }));
        btnSetting.onClick.Add(new EventDelegate(() =>
        {
            //打开SettingPanel
        }));
        btnQuit.onClick.Add(new EventDelegate(() =>
        {
            //退出游戏；
            Application.Quit();
        }));
        #endregion
    }
}
