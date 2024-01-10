using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


// 230905 ��ȣ�� commnet
// ���� �غ��ҽ��ϴ�. ������ ���غ��� ������ �ʿ��� �κе� �и��� ���� �Ŷ�� �����ϰ� �ֽ��ϴ�.
// ������ �κ��� �ּ����� ���� �޾ҽ��ϴ� Ȯ�����ֽð� ������ �ߴ� �κ��� �ְų� ���ذ� �ȵǽø� ������ֽø�
// �����ϰڽ��ϴ�. ���� �ڵ������� �ϸ鼭 ���� ������ ���Ҵµ�,
// useSkill �� skill�� �����°� �ƴ϶� tower�� �����°� ����?
// �̰Ŵ� �ǰ��� �� ��� �ͽ��ϴ�. 

[System.Serializable]
[CreateAssetMenu]
public class Skill : ScriptableObject
{
    public Sprite skillImage;
    public string skillOption;
    public string skillDamageText;
    public GameObject skillObj;

    public virtual int UseSkill(GameObject tower)
    {
        return tower.GetComponent<Tower>().status.atk;
    }
    public virtual int UseSkill( Status towerSt )
    {
        towerSt.mp = 0;

        
        return towerSt.atk;
    }
    public virtual void UseSkill( Soldier attacker , Vector3 targetPos , GameObject instantObj)
    {

    }
    public virtual void UseSkill(Vector3 targetPos)
    {
        return;
    }
    public virtual void UseSkill(Soldier attacker, Monster target)
    {
        return;
    }
    public virtual void UseSkill(Soldier attacker, Monster target, GameObject instantObj)
    {
        return;
    }
    // ���� ��ų�� ��Ÿ�ӿ� �� �ְų�, Ȥ�� ������ �������� üũ
    public virtual bool IsUseSkill( Status towerSt)
    {

        if (towerSt.maxMp == towerSt.mp)
        {
            return true;
        }
        return false;
    }
}
