using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : BasePanel<SettingPanel>
{
    public UIButton btnClose;
    public UISlider musicSlider, soundSlider;
    public UIToggle musicToggle, soundToggle;
    public override void Init()
    {
        #region 控件绑定事件
        btnClose.onClick.Add(new EventDelegate(()=>
        {
            HideMe();
        }));

        musicSlider.onChange.Add(new EventDelegate(()=>
        {
            //修改数据管理器中的音乐数据的值；
        }));

        soundSlider.onChange.Add(new EventDelegate(() =>
        {
            //修改数据管理器中的声音数据的值；
        }));

        musicToggle.onChange.Add(new EventDelegate(()=>
        {
            //修改数据管理器中的音乐数据的Mute；
        }));

        soundToggle.onChange.Add(new EventDelegate(() =>
        {
            //修改数据管理器中的声音数据的Mute；
        }));
        #endregion
        HideMe();

        //初始化读取DataManager中的音乐音量数据，设置Panel上的控件
    }
}
