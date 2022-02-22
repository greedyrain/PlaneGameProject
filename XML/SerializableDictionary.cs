using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

public class SerializableDictionary<TKey,TValue> : Dictionary<TKey,TValue>,IXmlSerializable
{
    public XmlSchema GetSchema()
    {
        return null;
    }

    public void ReadXml(XmlReader reader)
    {
        //自定义字典的反序列化规则；
        XmlSerializer keySer = new XmlSerializer(typeof(TKey));
        XmlSerializer ValueSer = new XmlSerializer(typeof(TValue));
        reader.Read();
        //reader.Read();
        while (reader.NodeType != XmlNodeType.EndElement)
        {
            TKey key = (TKey)keySer.Deserialize(reader);
            TValue value = (TValue)ValueSer.Deserialize(reader);
            Add(key, value);
        }
        reader.Read();
    }

    public void WriteXml(XmlWriter writer)
    {
        XmlSerializer keySer = new XmlSerializer(typeof(TKey));
        XmlSerializer ValueSer = new XmlSerializer(typeof(TValue));
        //自定义字典的序列化规则
        foreach (KeyValuePair<TKey,TValue> tk in this)
        {
            //要序列化需要一个序列化器，在上面声明；
            //有了序列化器后，直接调用里面的序列化方法，即可；
            keySer.Serialize(writer,tk.Key);
            ValueSer.Serialize(writer, tk.Value);
        }
    }
}
