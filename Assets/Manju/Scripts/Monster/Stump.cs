using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stump : Monster
{
    // Start is called before the first frame update
    void Start()
    {
        //�θ��ִ� ��ŸƮ�� ���� �����ϰ� �ڽĿ� �ִ� ��ŸƮ�� ����
        //base.Start();

        //������ �Ӽ�
        monsterInfo.name = "������";
        monsterInfo.hp = 10;
        monsterInfo.speed = 0.1f;
        monsterInfo.atk = 1;

    }

}
