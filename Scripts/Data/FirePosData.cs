using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class FirePosData
{
    [XmlAttribute]
    public int id, type, num, coolDown;
}

public class FirePosInfo
{
    public List<FirePosData> firePoses = new List<FirePosData>();
}
