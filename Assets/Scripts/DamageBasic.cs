using UnityEngine;

public class DamageBasic : MonoBehaviour
{
	[Header("資料")]
	public DataBasic data;

	private float hp;

	private void Awake()
	{
		hp = data.hp;
	}

	public void Damage(float damage)
	{
		hp -= damage;

		// 輸出誰受傷，剩多少血量。
		print($"<color=#ffee64>{gameObject.name} 血量剩下：{hp}</color>");

		if (hp <= 0) Dead();
	}

	private void Dead()
	{
		// 輸出誰死亡
		print($"<color=#ffee64>{gameObject.name} 死亡</color>");
	}
}
