using UnityEngine;

public class ExpSystem : MonoBehaviour
{
	private Transform player;
	[Header("移動速度"), Range(0,10)]
	public float speed = 3.5f;

	private void Awake()
	{
		player = GameObject.Find("衝鋒企鵝").transform;
	}

	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
	}
}
