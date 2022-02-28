using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//子弹的属性应该包括：
//子弹的行为应该包括：击中玩家、移动、自行销毁（飞出了屏幕就进行销毁）
public class BaseBullet : MonoBehaviour
{
    BulletData bulletData;
    public int type;
    Vector3 WTSPos;
    float rad = 0;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Player>().transform.GetChild(0);
        type = transform.parent.GetComponent<FirePos>().bulletType;
        bulletData = DataManager.Instance.BulletsInfo.bullets[type-1];
        Invoke("Dead", bulletData.destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        //默认移动
        BulletMove(type);
    }

    private void BulletMove(int type)
    {
        transform.Translate(Vector3.forward * bulletData.moveSpeed * Time.deltaTime);
        switch (type)
        {
            case 2://正弦移动
                rad += Time.deltaTime * bulletData.frequency;
                transform.Translate(Vector3.right * bulletData.amplitude * Mathf.Sin(rad));
                break;
            case 3://左抛物线
                transform.rotation *= Quaternion.AngleAxis(bulletData.rotateSpeed * Time.deltaTime, Vector3.up);//四元数乘以向量，获得一个新的向量；
                break;
            case 4://右抛物线
                transform.rotation *= Quaternion.AngleAxis(-bulletData.rotateSpeed * Time.deltaTime, Vector3.up);//四元数乘以向量，获得一个新的向量；
                break;
            case 5://追踪
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position) , Time.deltaTime * bulletData.rotateSpeed);
                break;
        }
        WTSPos = Camera.main.WorldToScreenPoint(transform.position);
        if (WTSPos.x < 0 || WTSPos.x > Screen.width || WTSPos.y < 0 || WTSPos.y > Screen.height)
            Destroy(gameObject);
    }

    public void Dead()
    {
        //被鼠标点击时，先创建一个特效
        GameObject effObj = Instantiate(Resources.Load<GameObject>(bulletData.deadEffect),transform.position,transform.rotation);
        //一秒后销毁特效
        Destroy(effObj, 1f);
        //销毁子弹
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player playerObj = other.transform.parent.GetComponent<Player>();
            print(playerObj);
            playerObj.GetHurt(1);
            Dead();
        }
    }
}
