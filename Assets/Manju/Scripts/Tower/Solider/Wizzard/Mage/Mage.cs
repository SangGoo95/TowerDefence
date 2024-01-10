using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Soldier
{
    [SerializeField] private GameObject baseAttackObj;
    protected override void Attack(GameObject targetObj)
    {
        // ����ü�� Ÿ������ ������ ���� ���� �� ĳ��
        if (targetObj.TryGetComponent<Monster>(out var monster))
        {
            AudioSource.PlayClipAtPoint(towerSoundList[(int)TowerSound.idleSound], transform.position);
            animator.SetTrigger("isAttack");
            GameObject bao = Instantiate(baseAttackObj, targetObj.transform.position, transform.rotation); // Ÿ���� ��ġ�� �⺻���� ����(��������)                                
            bao.GetComponent<FlooringObj>().SetAtk(status.atk);
        }
    }

    public override void UseSkill()
    {
        if (monsters.Count > 0 && status.mp == status.maxMp)
        {
            AudioSource.PlayClipAtPoint(towerSoundList[(int)TowerSound.skillSound], transform.position);
            status.mp = 0;
            status.towerSkills[0].UseSkill(SetTarget().transform.position);        
        }
    }
}
