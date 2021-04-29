using UnityEngine;
using MessagePack;

[MessagePackObject, System.Serializable]
public class SampleMessagePackObjectChild
{
    [Key(0)] public int id;
}

[MessagePackObject, System.Serializable]
public class SampleMessagePackObjectParent
{
    [Key(0)] public SampleMessagePackObjectChild[] children;
}

public class NestedSerializeDeserializeSample : MonoBehaviour
{
    public SampleMessagePackObjectParent serializedObject;
    public SampleMessagePackObjectParent deserializedObject;
    byte[] serializedData;

    void Start()
    {
        serializedData     = MessagePackSerializer.Serialize(serializedObject);
        deserializedObject = MessagePackSerializer.Deserialize<SampleMessagePackObjectParent>(serializedData);
    }

    void OnGUI()
    {
        GUILayout.Label("SerializedObject Hash : "   + serializedObject.GetHashCode());
        GUILayout.Label("DeSerializedObject Hash : " + deserializedObject.GetHashCode());
    }
}