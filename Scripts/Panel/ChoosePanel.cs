using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosePanel : BasePanel<ChoosePanel>
{
    public UIButton btnClose, btnLeft, btnRight, btnStart;
    public Transform HP, speed, volume, heroPos;
    int key;
    GameObject plane;
    HeroData heroData;
    public override void Init()
    {
        key = 1;
        CreatHero(key);
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
            Destroy(plane);
            key -= 1;
            if (key <= 0)
                key = DataManager.Instance.HerosInfo.herosDic.Count;
            CreatHero(key);
        }));

        btnRight.onClick.Add(new EventDelegate(() =>
        {
            //切换到下一个飞机
            Destroy(plane);
            key += 1;
            if (key > DataManager.Instance.HerosInfo.herosDic.Count)
                key = 1;
            CreatHero(key);
        }));

        btnStart.onClick.Add(new EventDelegate(() =>
        {
            //开始游戏
            DataManager.Instance.planeKey = key;
            SceneManager.LoadScene("GameScene");
        }));
        #endregion
        HideMe();
    }

    public void CreatHero(int key)
    {
        //通过Instantiate方法生成一个预设体，放到HeroPos下，然后修改其缩放；
        heroData = DataManager.Instance.HerosInfo.herosDic[key];//读取数据，方便在下方的数据框中显示
        plane = Instantiate(Resources.Load<GameObject>($"Airplane/Airplane{key}"), heroPos);//生成
        plane.transform.localScale = new Vector3(1, 1, 1) * heroData.scale;//修改缩放
        plane.layer = 5;//设置层级
        SetGrid(HP, heroData.HP);//设置HP数据
        SetGrid(speed, heroData.speed);//设置Speed数据
        SetGrid(volume, heroData.volume);//设置Volume数据
    }

    public void SetGrid(Transform trans, int count)
    {
        for (int i = 0; i < trans.childCount; i++)
        {
            trans.GetChild(i).GetChild(0).gameObject.SetActive(false);
        }

        for (int i = 0; i < count; i++)
        {
            trans.GetChild(i).GetChild(0).gameObject.SetActive(true);
        }
    }
}
