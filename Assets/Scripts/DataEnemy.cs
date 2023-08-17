using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Leo/Data Enemy")]
public class DataEnemy : DataBasic
{
	[Header("掉落經驗值機率"), Range(0, 1)]
	public float expProbability;
	[Header("掉落經驗值預製物")]
	public GameObject prefabExp;
	[Header("攻擊範圍"), Range(0, 50)]
	public float attackRange = 2f;
	[Header("攻擊間隔"), Range(0, 1)]
	public float attackInterval = 2.5f;
}
