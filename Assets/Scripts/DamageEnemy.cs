using UnityEngine;

public class DamageEnemy : DamageBasic
{
	private DataEnemy dataEnemy;

	private void Start()
	{
		// 將資料轉為敵人資料
		dataEnemy = (DataEnemy)data;
		//print(dataEnemy.expProbability);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name.Contains("武器")) 
		{
			float damage = collision.gameObject.GetComponent<Weapon>().attack;

			Damage(damage);

		}
	}

	protected override void Dead()
	{
		base.Dead();        // 父類別原有的內容
		Destroy(gameObject);

		if(Random.value < dataEnemy.expProbability)
		{
			Instantiate(dataEnemy.prefabExp, transform.position, transform.rotation);
		}
	}
}
