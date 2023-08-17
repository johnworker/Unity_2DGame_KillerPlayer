using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Leo/Data Enemy")]
public class DataEnemy : DataBasic
{
	[Header("�����g��Ⱦ��v"), Range(0, 1)]
	public float expProbability;
	[Header("�����g��ȹw�s��")]
	public GameObject prefabExp;
	[Header("�����d��"), Range(0, 50)]
	public float attackRange = 2f;
	[Header("�������j"), Range(0, 1)]
	public float attackInterval = 2.5f;
}
