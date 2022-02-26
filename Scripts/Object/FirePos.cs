using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePos : MonoBehaviour
{
    public int type,bulletCount;
    float fireCD, remainCD,moveSpeed;
    
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
        for (int i = 0; i < bulletCount; i++)//生成子弹实例
        {
            GameObject bullet = Instantiate(Resources.Load<GameObject>($"Bullet/Bullet{type}"), transform);
            bullet.transform.rotation = Quaternion.AngleAxis(90 / bulletCount * i, Vector3.up);//修改子弹的面朝向；
            bullet.AddComponent<BaseBullet>();//给子弹添加脚本，让其自动完成移动、自毁相关功能
        }
        Reset();
    }

    private void Reset()
    {
        //重新随机一个type，重新随机CD
        type = Random.Range(1, DataManager.Instance.BulletsInfo.bullets.Count + 1);
        fireCD = Random.Range(3, 7);
        bulletCount = Random.Range(1, 5);
        remainCD = 0;//重置CD
    }
}
