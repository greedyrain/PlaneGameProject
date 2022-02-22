using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    public UIButton btnClose;
    public Transform scrollView;
    public override void Init()
    {
        #region 控件绑定事件
        btnClose.onClick.Add(new EventDelegate(()=>
        {
            HideMe();
        }));
        #endregion
        HideMe();
        //初始化读取排行榜数据，根据排行榜数据生成对应个数的RankItem对象
    }
}
