using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class HeroData
{
    [XmlAttribute]
    public int HP;
    [XmlAttribute]
    public int speed;
    [XmlAttribute]
    public int volume;
}

public class HerosInfo
{
    public SerializableDictionary<int, HeroData> herosDic = new SerializableDictionary<int, HeroData>();
}
