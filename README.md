# Unity_MessagePackSample

This repository provides simplest sample of [MessagePack-CSharp](https://github.com/neuecc/MessagePack-CSharp).

MessagePack resources are licensed under the other licence (Not same as this repository's one).

## Example

```csharp
[MessagePackObject, System.Serializable]
public class SampleMessagePackObject
{
    [Key(0)] public int     id;
    [Key(1)] public float   value;
    [Key(2)] public string  name;
    [Key(3)] public Vector3 position;

    // NOTE:
    // public string keyLess;
    // This makes following error.
    // "all public members must mark KeyAttribute or IgnoreMemberAttribute."
}

public class SerializeDeserializeSample : MonoBehaviour
{
    public SampleMessagePackObject serializedObject;
    public SampleMessagePackObject deserializedObject;
    byte[] serializedData;

    void Start()
    {
        serializedData     = MessagePackSerializer.Serialize(serializedObject);
        deserializedObject = MessagePackSerializer.Deserialize<SampleMessagePackObject>(serializedData);
    }

    void OnGUI()
    {
        GUILayout.Label("SerializedObject Hash : "   + serializedObject.GetHashCode());
        GUILayout.Label("DeSerializedObject Hash : " + deserializedObject.GetHashCode());
    }
}
```
