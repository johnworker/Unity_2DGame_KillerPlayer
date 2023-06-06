using UnityEngine;

public class WeaponSpawn : MonoBehaviour
{
	public float interval = 3f;

	public GameObject prefabWeapon;

	private void SpawnWeapon()
	{
		Instantiate(prefabWeapon, transform.position, transform.rotation);
	}

	private void Awake()
	{
		InvokeRepeating("SpawnWeapon", 0, interval);
	}
}
