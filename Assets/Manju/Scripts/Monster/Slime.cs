using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slime : Monster
{
    // Start is called before the first frame update
    new void Start()
    {
        //�θ��ִ� ��ŸƮ�� ���� �����ϰ� �ڽĿ� �ִ� ��ŸƮ�� ����
        base.Start();

        //������ �Ӽ�
        monsterInfo.name = "������";
        monsterInfo.hp = 5;
        monsterInfo.atk = 1;
        monsterInfo.speed = 0.01f;


    }

}
