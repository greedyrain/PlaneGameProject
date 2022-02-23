using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    public UIButton btnClose;
    public Transform scrollView;
    List<RankItem> list = new List<RankItem>();
    public override void Init()
    {
        #region 控件绑定事件
        btnClose.onClick.Add(new EventDelegate(()=>
        {
            HideMe();
        }));
        #endregion
        HideMe();
    }

    public override void ShowMe()
    {
        //初始化读取排行榜数据，根据排行榜数据生成对应个数的RankItem对象
        base.ShowMe();
        for (int i = 0; i < list.Count; i++)
        {
            Destroy(list[i].gameObject);
        }
        list.Clear();

        for (int i = 0; i < DataManager.Instance.RankInfo.rankList.Count; i++)
        {
            RankItem item = Instantiate(Resources.Load<RankItem>("RankItem"),scrollView);
            item.RewriteRank(DataManager.Instance.RankInfo.rankList[i].rank);
            item.RewriteName(DataManager.Instance.RankInfo.rankList[i].name);
            item.RewriteTime(DataManager.Instance.RankInfo.rankList[i].time);
            item.transform.localPosition = new Vector3(0,-90 * i,0);
            list.Add(item);
        }
    }
}
