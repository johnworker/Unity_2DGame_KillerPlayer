using UnityEngine;
using UnityEngine.UI;

public class DamagePlayer : DamageBasic
{
    public Image imgHp;

    /*
    private void Start()
    {
        Damage(50);
    }*/

    protected override void Damage(float damage)
    {
        // 繼承 DataBasic 的資料定義和方法運算
        base.Damage(damage);
        
        imgHp.fillAmount = hp / hpMax;
    }
}
