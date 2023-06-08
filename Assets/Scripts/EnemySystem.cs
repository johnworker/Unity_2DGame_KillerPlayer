using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
	private Transform player;

	private void Awake()
	{
		player = GameObject.Find("衝鋒企鵝").transform;
	}

	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, player.position, 0.01f);
	}
}
