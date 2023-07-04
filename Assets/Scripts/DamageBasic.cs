using UnityEngine;
using TMPro;

public class DamageBasic : MonoBehaviour
{
	[Header("���")]
	public DataBasic data;
	[Header("�ˮ`�ȹw�m��")]
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
		// �ͦ����ˮ`�Ȫ���|�x�s�b�W�� tempDamage ����Ƥ���K�s��

		tempDamage.transform.Find("�ˮ`�Ȥ�r").GetComponent<TextMeshProUGUI>().text = damage.ToString();
		// tempDamage.transform.Find("�ˮ`�Ȥ�r")
		// ���ͦ����ˮ`�Ȫ��� ���U �W��&#xff02;�ˮ`�Ȥ�r&#xff02;���l����

		// GetComponent<TextMeshProUGUI>().text = damage.ToString();
		// ���o�l���󨭤W��<TextMeshProUGUI> ��r���� �ç�s��r�� �ˮ`��

		// ��X�֨��ˡA�Ѧh�֦�q�C
		print($"<color=#ffee64>{gameObject.name} ��q�ѤU�G{hp}</color>");

		if (hp <= 0) Dead();
	}

	protected virtual void Dead()
	{
		// ��X�֦��`
		print($"<color=#ffee64>{gameObject.name} ���`</color>");
	}
}
