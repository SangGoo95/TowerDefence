using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archmage : Soldier
{
    [SerializeField] private GameObject baseAttackObj;

    protected override void Attack(GameObject targetObj)
    {
        // ����ü�� Ÿ������ ������ ���� ���� �� ĳ��
        if (targetObj.TryGetComponent<Monster>(out var monster))
        {
            AudioSource.PlayClipAtPoint(towerSoundList[(int)TowerSound.idleSound], transform.position);
            animator.SetTrigger("isAttack");
            Quaternion qua = transform.rotation;
            qua.eulerAngles = new Vector3(0, 90, -115);
            GameObject bao = Instantiate(baseAttackObj, targetObj.transform.position, qua); // Ÿ���� ��ġ�� �⺻���� ����(��������)                    
            bao.GetComponent<wizzardBaseObj>().SetAtk(status.atk);
        }
    }

    public override void UseSkill()
    {
        if(status.mp != status.maxMp)
        {
            return;
        }

        AudioSource.PlayClipAtPoint(towerSoundList[(int)TowerSound.skillSound], transform.position);
        status.mp = 0;
        status.towerSkills[0].UseSkill(gameObject);
    }
}
