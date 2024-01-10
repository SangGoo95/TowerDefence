using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Soldier
{    
    // ���ڵ�� rangeObj
    [SerializeField] private GameObject baseAttackObj;

    protected override void Attack(GameObject targetObj)
    {
        // ����ü�� Ÿ������ ������ ���� ���� �� ĳ��
        if (targetObj.TryGetComponent<Monster>(out var monster))
        {
            AudioSource.PlayClipAtPoint(towerSoundList[(int)TowerSound.idleSound], transform.position);
            animator.SetTrigger("isAttack");            
            GameObject bao = Instantiate(baseAttackObj, transform.position, transform.rotation); // �� ��ġ���� ����            
            bao.GetComponent<ChaseObj>().SetTarget(targetObj, transform.position, status.atk);
        }
    }

    public override void UseSkill()
    {
        if (status.mp != status.maxMp)
            return;

        AudioSource.PlayClipAtPoint(towerSoundList[(int)TowerSound.skillSound], transform.position);
        status.mp = 0;
        status.towerSkills[0].UseSkill(gameObject);
    }
}
