using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosePanel : BasePanel<ChoosePanel>
{
    public UIButton btnClose, btnLeft, btnRight, btnStart;
    public GameObject RFX;
    public override void Init()
    {
        CreatHero(1);
        #region 控件绑定事件
        btnClose.onClick.Add(new EventDelegate(() =>
        {
            //打开BeginPanel，关闭自身；
            BeginPanel.Instance.ShowMe();
            HideMe();
        }));

        btnLeft.onClick.Add(new EventDelegate(() =>
        {
            //切换到上一个飞机
        }));

        btnRight.onClick.Add(new EventDelegate(() =>
        {
            //切换到下一个飞机
        }));

        btnStart.onClick.Add(new EventDelegate(() =>
        {
            //开始游戏
            SceneManager.LoadScene("GameScene");
            DontDestroyOnLoad(RFX);
        }));
        #endregion
        HideMe();
    }

    public void CreatHero(int key)
    {
        //通过Instantiate方法生成一个预设体，放到HeroPos下，然后修改其缩放；
        HeroData hero = DataManager.Instance.HerosInfo.herosDic[key];
    }
}
