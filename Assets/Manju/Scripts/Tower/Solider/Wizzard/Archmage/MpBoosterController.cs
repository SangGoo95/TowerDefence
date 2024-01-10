using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MpBoosterController : MonoBehaviour
{
    int skillTime;
    float atkSpeed;
    Soldier attacker;
    void Start()
    {
        atkSpeed = attacker.status.atkSpeed;
        skillTime = 5; // �����ѹ� �ν����Ϳ��� ����
        attacker.isAttack = true;
        StartCoroutine(DelayCo());
    }
    
    IEnumerator DelayCo()
    {
        attacker.status.atkSpeed = 0.5f; // �����ѹ� �ν����Ϳ��� ����
        yield return new WaitForSeconds(skillTime);
        attacker.status.atkSpeed = atkSpeed;
    }

    public void SetAttack(Soldier attacker)
    {
        this.attacker = attacker;
    }
}
