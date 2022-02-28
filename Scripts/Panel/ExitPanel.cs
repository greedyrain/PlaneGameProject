using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPanel : BasePanel<ExitPanel>
{
    public UIButton btnConfirm,btnCancel;
    public override void Init()
    {
        #region 控件绑定事件
        btnConfirm.onClick.Add(new EventDelegate(()=>
        {
            //打开BeginPanel，关闭自己，关闭GamePanel；
            Time.timeScale = 1;
            SceneManager.LoadScene("BeginScene");
        }));

        btnCancel.onClick.Add(new EventDelegate(() =>
        {
            //关闭自己；
            Time.timeScale = 1;
            HideMe();
        }));
        HideMe();
        #endregion
    }
}
