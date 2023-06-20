using UnityEngine;

public class DamageBasic : MonoBehaviour
{
	[Header("���")]
	public DataBasic data;

	private float hp;

	private void Awake()
	{
		hp = data.hp;
	}

	public void Damage(float damage)
	{
		hp -= damage;

		// ��X�֨��ˡA�Ѧh�֦�q�C
		print($"<color=#ffee64>{gameObject.name} ��q�ѤU�G{hp}</color>");

		if (hp <= 0) Dead();
	}

	private void Dead()
	{
		// ��X�֦��`
		print($"<color=#ffee64>{gameObject.name} ���`</color>");
	}
}
