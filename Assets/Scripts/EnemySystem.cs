using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
	[Header("敵人資料")]
	public DataEnemy data;

	private Transform player;

	private float timer;

	private void OnDrawGizmos()
	{
		Gizmos.color = new Color(1, 0, 0.3f, 0.5f);
		Gizmos.DrawSphere(transform.position, data.attackRange);
	}


	private void Awake()
	{
		player = GameObject.Find("衝鋒企鵝").transform;
	}

	private void Update()
	{
		// Vector3.Distance (計算兩個點的距離)
		float distance = Vector3.Distance(transform.position, player.position);

		if(distance > data.attackRange)
        {
			transform.position = Vector3.MoveTowards(transform.position, player.position, data.moveSpeed * Time.deltaTime);
        }
        else
        {
			timer += Time.deltaTime;
        }
	}
}
