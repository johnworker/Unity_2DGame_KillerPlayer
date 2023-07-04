﻿using UnityEngine;

public class WeaponSpawn : MonoBehaviour
{
	[Header("生成間隔"), Range(0, 10)]
	public float interval = 3f;
	[Header("生成武器預置物")]
	public GameObject prefabWeapon;
	[Header("武器推力")]
	public Vector2 power;
	

	private void SpawnWeapon()
	{
		GameObject tempWeapon = Instantiate(prefabWeapon, transform.position, transform.rotation);

		Rigidbody2D rigWeapon = tempWeapon.GetComponent<Rigidbody2D>();


		rigWeapon.AddForce(power);
	}

	private void Awake()
	{
		InvokeRepeating("SpawnWeapon", 0, interval);
	}
}

