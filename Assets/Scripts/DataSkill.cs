using UnityEngine;

[CreateAssetMenu(menuName = "Leo/Data Skill")]
public class DataSkill : ScriptableObject
{
    [Header("�ޯ�W��")]
    public string skillName;
    [Header("�ޯ�Ϥ�")]
    public Sprite skillPicture;
    [Header("�ޯ�y�z")]
    public string skillDescription;
    [Header("�ޯ൥��")]
    public int skillLv;
    [Header("�ޯ�ƭ�")]
    public float[] skillValues;
}
