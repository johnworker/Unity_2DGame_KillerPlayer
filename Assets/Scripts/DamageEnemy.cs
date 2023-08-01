using UnityEngine;

public class DamageEnemy : DamageBasic
{
	private DataEnemy dataEnemy;

	private void Start()
	{
		// �N����ର�ĤH���
		dataEnemy = (DataEnemy)data;
		//print(dataEnemy.expProbability);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name.Contains("�Z��")) 
		{
			float damage = collision.gameObject.GetComponent<Weapon>().attack;

			Damage(damage);

		}
	}

	protected override void Dead()
	{
		base.Dead();        // �����O�즳�����e
		Destroy(gameObject);

		if(Random.value < dataEnemy.expProbability)
		{
			Instantiate(dataEnemy.prefabExp, transform.position, transform.rotation);
		}
	}
}
