using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
	[Header("�ͦ����j"), Range(0, 10)]
	public float interval = 3.5f;

	[Header("�ͦ��Ǫ��w�m��")]
	public GameObject prefabEnemy;

	private void SpawnEnemy()
	{
		Instantiate(prefabEnemy, transform.position, transform.rotation);
	}

	private void Awake()
	{
		InvokeRepeating("SpawnEnemy", 0, interval);
	}
}
