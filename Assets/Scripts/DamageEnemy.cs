﻿using UnityEngine;
using UnityEngine.Events;

public class DamageEnemy : DamageBasic
{
	private DataEnemy dataEnemy;

	[Header("死亡事件")]
	public UnityEvent onDead;

	private DamagePlayer damagePlayer;

	private void Start()
	{
		// 將資料轉為敵人資料
		dataEnemy = (DataEnemy)data;
		//print(dataEnemy.expProbability);

		damagePlayer = GameObject.Find("衝鋒企鵝").GetComponent<DamagePlayer>();
		if(name.Contains("BOSS")) onDead.AddListener(() => damagePlayer.Win());
	}

    private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name.Contains("武器")) 
		{
			float damage = collision.gameObject.GetComponent<Weapon>().attack;

			Damage(damage);

			AudioClip sound = SoundManager.instance.soundEnemyHurt;
			SoundManager.instance.PlaySound(sound, 0.8f, 1.2f);

		}
	}

	protected override void Dead()
	{
		base.Dead();        // 父類別原有的內容

		AudioClip sound = SoundManager.instance.soundEnemyDead;
		SoundManager.instance.PlaySound(sound, 0.8f, 1.2f);

		onDead.Invoke();
		Destroy(gameObject);

		if(Random.value < dataEnemy.expProbability)
		{
			Instantiate(dataEnemy.prefabExp, transform.position, transform.rotation);
		}
	}
}
