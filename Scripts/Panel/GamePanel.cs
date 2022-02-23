using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    public UIButton btnClose;
    public UILabel timeLabel;
    public override void Init()
    {
        #region 控件绑定事件
        btnClose.onClick.Add(new EventDelegate(()=>
        {
            //暂停游戏，打开ExitPanel；
            Time.timeScale = 0;
            ExitPanel.Instance.ShowMe();
        }));
        #endregion
    }

    public void UpdateTimeLabel(int time)
    {
        timeLabel.text = time.ToString();
    }
}
