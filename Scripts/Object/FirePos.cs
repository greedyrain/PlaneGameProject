using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePos : MonoBehaviour
{
    //根据id随机去表里读取一个数据，来生成该点的数据，
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
}
