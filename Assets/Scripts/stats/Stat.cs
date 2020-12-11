using UnityEngine;

[System.Serializable]
public class Stats
{
    [SerializeField]
    private int basevalue;

    public int GetValue()
    {
        return basevalue;
    }

}
