using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum E_FirePos
{
    TopLeft, TopCenter, TopRight, Left, Right, BottomLeft, BottomCenter, BottomRight
}

public class FirePos : MonoBehaviour
{
    //根据id随机去表里读取一个数据，来生成该点的数据，
    public E_FirePos e_FirePos = E_FirePos.TopLeft;
    private Vector3 screenPos;
    FirePosData firePosData;
    public int bulletType,bulletCount,id;
    float fireCD, remainCD;
    
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        SetPosition();
        //根据时间开火
        remainCD += Time.deltaTime;
        if (remainCD >= fireCD)
        {
            Fire();
        }
        //无时无刻移动
        
    }

    void Fire()
    {
        Reset();
        for (int i = 0; i < firePosData.num; i++)//生成子弹实例
        {
            GameObject bullet = Instantiate(Resources.Load<GameObject>($"Bullet/Bullet{bulletType}"), transform);
            bullet.transform.rotation = Quaternion.AngleAxis(90 / firePosData.num * i, Vector3.up);//修改子弹的面朝向；
            bullet.AddComponent<BaseBullet>();//给子弹添加脚本，让其自动完成移动、自毁相关功能
        }
    }

    private void Reset()
    {
        //重新随机一个id,去调取Xml中的对应的FirePos配置，获取type等的数据；
        id = Random.Range(0, DataManager.Instance.FirePosInfo.firePoses.Count);//获得随机数；
        firePosData = DataManager.Instance.FirePosInfo.firePoses[id];//读取对应的数据；
        bulletType = firePosData.type;
        fireCD = firePosData.coolDown;
        bulletCount = firePosData.num;
        remainCD = 0;//重置CD
    }

    void SetPosition()
    {
        screenPos.z = 0;
        switch (e_FirePos)
        {
            case E_FirePos.TopLeft:
                screenPos.x = 0;
                screenPos.y = Screen.height;
                transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
                break;
            case E_FirePos.TopCenter:
                screenPos.x = Screen.width / 2;
                screenPos.y = Screen.height;
                transform.rotation = Quaternion.AngleAxis(135, Vector3.up);
                break;
            case E_FirePos.TopRight:
                screenPos.x = Screen.width;
                screenPos.y = Screen.height;
                transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
                break;
            case E_FirePos.Left:
                screenPos.x = 0;
                screenPos.y = Screen.height / 2;
                transform.rotation = Quaternion.AngleAxis(45, Vector3.up);
                break;
            case E_FirePos.Right:
                screenPos.x = Screen.width;
                screenPos.y = Screen.height / 2;
                transform.rotation = Quaternion.AngleAxis(-45, Vector3.up);
                break;
            case E_FirePos.BottomLeft:
                screenPos.x = 0;
                screenPos.y = 0;
                transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
                break;
            case E_FirePos.BottomCenter:
                screenPos.x = Screen.width / 2;
                screenPos.y = 0;
                transform.rotation = Quaternion.AngleAxis(-45, Vector3.up);
                break;
            case E_FirePos.BottomRight:
                screenPos.x = Screen.width;
                screenPos.y = 0;
                transform.rotation = Quaternion.AngleAxis(-90, Vector3.up);
                break;
        }
        transform.position = Camera.main.ScreenToWorldPoint(screenPos);
        print(screenPos);
    }
}
