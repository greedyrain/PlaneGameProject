using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BulletData
{
    [XmlAttribute]
    public int type,destroyTime;
    [XmlAttribute]
    public float moveSpeed,hMoveSpeed,rotateSpeed;
    [XmlAttribute]
    public string resName, deadEffect;
}

public class BulletsInfo
{
    public List<BulletData> bullets = new List<BulletData>();
}