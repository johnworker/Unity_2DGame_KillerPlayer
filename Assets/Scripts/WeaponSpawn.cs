using UnityEngine;

public class WeaponSpawn : MonoBehaviour
{
	[Header("�ͦ����j"), Range(0, 10)]
	public float interval = 3f;
	[Header("�ͦ��Z���w�m��")]
	public GameObject prefabWeapon;
	[Header("�Z�����O")]
	public Vector2 power;

	private void SpawnWeapon()
	{
		GameObject tempWeapon = Instantiate(prefabWeapon, transform.position, transform.rotation);

		Rigidbody2D rigWeapon = tempWeapon.GetComponent<Rigidbody2D>();
	}

	private void Awake()
	{
		InvokeRepeating("SpawnWeapon", 0, interval);
	}
}
