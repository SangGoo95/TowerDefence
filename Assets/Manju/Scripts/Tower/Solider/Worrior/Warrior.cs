using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Soldier
{
    public GameObject idleAttackObj;

    private new void Start()
    {
        // �ڽĿ��� ��ŸƮ�� ������ �̰� ����
        base.Start();
        // ��ŸƮ �Ⱦ����� �̰� ��ü�� �� ����������
    }

    protected override void Attack(GameObject targetObj)
    {
        if (targetObj.TryGetComponent<Monster>(out var monster))
        {
            AudioSource.PlayClipAtPoint(towerSoundList[(int)TowerSound.idleSound], transform.position);
            animator.SetTrigger("isAttack");
            monster.TakeDamage(GetDamage());

            Vector3 createPos = transform.position;
            createPos += transform.forward / 2;
            Quaternion createRot = transform.rotation;
            GameObject idleAttack = Instantiate(idleAttackObj, createPos, createRot);
        }
    }

    public override void UseSkill()
    {

        if (status.mp != status.maxMp)
            return;

        status.mp = 0;
        AudioSource.PlayClipAtPoint(towerSoundList[(int)TowerSound.skillSound], transform.position);
        animator.SetTrigger("isAttack");
        status.towerSkills[0].UseSkill(gameObject);
    }
}
