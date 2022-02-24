using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel>
{
    public UIButton btnClose;
    public UILabel timeLabel;
    public Transform HPGrid;
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

    public void SetHP(int num)//传入一个数值，就能够设置玩家的血量；
    {
        for (int i = 0; i < HPGrid.childCount; i++)
        {
            HPGrid.GetChild(i).GetChild(0).gameObject.SetActive(false);
        }
        for (int i = 0; i < num; i++)
        {
            HPGrid.GetChild(i).GetChild(0).gameObject.SetActive(true);
        }
    }
}
