using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int planeKey;
    GameObject plane;
    public float moveH, moveV, moveSpeed, rotateSpeed;
    public int HP;
    public bool isDead;
    public Transform HPGrid;
    Quaternion quat;
    Vector3 scPos, lastPos;
    // Start is called before the first frame update
    void Start()
    {
        planeKey = DataManager.Instance.planeKey;
        HP = DataManager.Instance.HerosInfo.herosDic[planeKey].HP;
        moveSpeed = DataManager.Instance.HerosInfo.herosDic[planeKey].speed * 50;
        rotateSpeed = DataManager.Instance.HerosInfo.herosDic[planeKey].rotateSpeed;
        print(HP);
        plane = Instantiate(Resources.Load<GameObject>($"Airplane/Airplane{planeKey}"), transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            Dead();
            return;
        }
            

        moveH = Input.GetAxisRaw("Horizontal");
        moveV = Input.GetAxisRaw("Vertical");

        if (moveH == 0)
            quat = Quaternion.identity;
        else
            quat = moveH < 0 ? Quaternion.AngleAxis(20, Vector3.forward) : Quaternion.AngleAxis(-20, Vector3.forward);

        plane.transform.rotation = Quaternion.Lerp(plane.transform.rotation, quat, rotateSpeed * Time.deltaTime);

        lastPos = plane.transform.position;

        plane.transform.Translate(Vector3.forward * moveV * moveSpeed * Time.deltaTime, Space.World);
        plane.transform.Translate(Vector3.right * moveH * moveSpeed * Time.deltaTime, Space.World);

        scPos = Camera.main.WorldToScreenPoint(plane.transform.position);
        if (scPos.x <= 0 || scPos.x >= Screen.width)
            plane.transform.position = new Vector3(lastPos.x, plane.transform.position.y, plane.transform.position.z);

        if (scPos.y <= 0 || scPos.y >= Screen.height)
            plane.transform.position = new Vector3(plane.transform.position.x, plane.transform.position.y, lastPos.z);
    }

    public void GetHurt(int num)//传入一个数值，就能够设置玩家的血量；
    {
        HP -= num;
        if (HP <=0)
        {
            isDead = true;
        }
        GamePanel.Instance.SetHP(num);
    }

    public void Dead()
    {
        Time.timeScale = 0;
        //打开GameOverPanel
        Destroy(plane,1);
        GameOverPanel.Instance.ShowMe();
    }
}
