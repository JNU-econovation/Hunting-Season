using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity
{
    [SerializeField] private int criticalRate;
    [SerializeField] private int criticalDamage;

    private void Start()
    {
        CanvasManager.Instance.SetHpImg(hp, maxHP);
    }

    public int GetSpeed()
    {
        return speed;
    }

    public void IncreaseHP(int n)
    {
        hp += n;
        if (hp >= maxHP)
        {
            hp = maxHP;
        }
        CanvasManager.Instance.SetHpImg(hp, maxHP);
    }
}
