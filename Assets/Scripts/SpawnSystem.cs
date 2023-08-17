﻿using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
	[Header("生成間隔"), Range(0, 10)]
	public float interval = 3.5f;

	[Header("生成怪物預置物")]
	public GameObject prefabEnemy;

	private void SpawnEnemy()
	{
		Instantiate(prefabEnemy, transform.position, transform.rotation);
	}

	private void Awake()
	{
		InvokeRepeating("SpawnEnemy", 0, interval);
	}

	public void Restart()
    {
		CancelInvoke();
		InvokeRepeating("SpawnEnemy", 0, interval);
	}
}
