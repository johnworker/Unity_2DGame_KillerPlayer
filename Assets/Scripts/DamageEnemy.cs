using UnityEngine;

public class DamageEnemy : DamageBasic
{
	[Header("�ˮ`�ȹw�m��")]
	public GameObject prefabDamage;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name.Contains("�Z��")) 
		{ 
			Damage(50);

			Instantiate(prefabDamage, transform.position, transform.rotation);
		}
	}
}
