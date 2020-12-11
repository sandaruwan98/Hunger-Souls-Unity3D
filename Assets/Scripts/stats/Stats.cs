using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private int basevalue;

    public int GetValue()
    {
        return basevalue;
    }

}
