using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 23.09.05 ��ȣ�� comment

// public Skill skill ���� => public List<Skill> towerSkils; �� ����


[System.Serializable]
public class Status
{
    public int cost; // Ÿ�� ����
    public int atk; // ��Ÿ ������
    public float atkSpeed; // ��Ÿ �ӵ�
    public int mp; // ���� Mp
    public int recoveryMp; // Mp ȸ����
    public int maxMp; // �ִ� Mp

    // �� Ÿ���� �´�  ��ũ��Ʈ �巡�׾� ��� �ϱ�
    public List<Skill> towerSkills;
}


public class Tower : MonoBehaviour
{
    public Status status;
    public GameObject nextLevelTower;

    public virtual int GetCost()
    {
        return status.cost;
    }

    public virtual List<Skill> GetTowerSkills()
    {
        return status.towerSkills;
    }

    public virtual void UseSkill()
    {
        if(status.towerSkills.Count > 0 && status.mp == status.maxMp)
        {
            status.towerSkills[0].UseSkill(status);
        }
    }
}
