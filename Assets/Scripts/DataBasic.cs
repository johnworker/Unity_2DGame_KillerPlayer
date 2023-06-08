using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Leo/Data Basic")]
public class DataBasic : ScriptableObject
{
	[Header("��q"), Range(0, 10000)]
	public float hp;
	[Header("�����O"), Range(0, 1000)]
	public float attack;
	[Header("���ʳt��"), Range(0, 100)]
	public float moveSpeed;
}
