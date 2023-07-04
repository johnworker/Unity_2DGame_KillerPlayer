using UnityEngine;
using TMPro;

public class DamageBasic : MonoBehaviour
{
	[Header("資料")]
	public DataBasic data;
	[Header("傷害值預置物")]
	public GameObject prefabDamage;


	private float hp;

	private void Awake()
	{
		hp = data.hp;
	}

	public void Damage(float damage)
	{
		hp -= damage;

		GameObject tempDamage = Instantiate(prefabDamage, transform.position, transform.rotation);
		// 生成的傷害值物件會儲存在名為 tempDamage 的資料內方便存取

		tempDamage.transform.Find("傷害值文字").GetComponent<TextMeshProUGUI>().text = damage.ToString();
		// tempDamage.transform.Find("傷害值文字")
		// 找到生成的傷害值物件 底下 名為&#xff02;傷害值文字&#xff02;的子物件

		// GetComponent<TextMeshProUGUI>().text = damage.ToString();
		// 取得子物件身上的<TextMeshProUGUI> 文字元件 並更新文字為 傷害值

		// 輸出誰受傷，剩多少血量。
		print($"<color=#ffee64>{gameObject.name} 血量剩下：{hp}</color>");

		if (hp <= 0) Dead();
	}

	protected virtual void Dead()
	{
		// 輸出誰死亡
		print($"<color=#ffee64>{gameObject.name} 死亡</color>");
	}
}
