using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 230901 made by ��ȣ��

// interface �Դϴ�. (�������̽� ��� ��Ģ�� CamelCase�� ~~ Able ���� ������ �ۼ��Ͻô°� �����ϴ�.)
// �Լ��� ������ ������, ���� ���Ǵ� ���� �ʾƼ� �ش� ���Ǵ� �̰� �޴� ģ���� ���� �����ϸ� �ϼ��Դϴ�.

// !! TODO_LIST ������ �ѹ� �ϰ�����, �� �������� ������ �ϴ� soldier Ŭ������
// ���� ���õ� ���� �ϰ� �Ǵ� famer Ŭ������ ������ ���� ���ٴ� ������ ������ϴ�. �׷���
// ���� ���� �� �ְ� �� �ϴ� �Լ����� �����ؾ� ���� �˸��� �������̽��� IncomeAble�� �����ϰ� �Ǿ����ϴ�.


interface IncomeAble
{

    void RaiseIncome();
    void DownIncome();

}
