using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 230901 made by ��ȣ��


// !! TODO_LIST 
// �ش� �������̽����� �����ؾ� �ϴ� �͵��� '���ݰ� ���õ� �⺻�� ���' �Դϴ�.
// ���� ���� �͵��� ���� ������ ������, ���� �� �ʿ��ϴٰ� �����Ͻô� �κ��� ���� ������ ���� ���ð�
// ī��濡 �÷��� ������ �ֽø� �����ϰڽ��ϴ�. interface�� ���� Ŭ���� ���� ���� ������ �ʿ��� ���� �����Դϴ�.

   

public interface IAttackAble
{
    float CalDamage(int damage); // private
    float GetDamage(); // return CalDamage();

    // ���� �߰� ����
}