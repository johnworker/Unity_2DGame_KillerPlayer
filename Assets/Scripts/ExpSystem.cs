using UnityEngine;

public class ExpSystem : MonoBehaviour
{
	private Transform player;

	private void Awake()
	{
		player = GameObject.Find("�ľW���Z").transform;
	}

	private void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, player.position, 0.01f);
	}
}
