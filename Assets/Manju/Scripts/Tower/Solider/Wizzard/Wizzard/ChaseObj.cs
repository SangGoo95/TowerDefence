using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseObj : MonoBehaviour
{
    // ȭ�������տ� �پ����� ��ũ��Ʈ    
    GameObject target;    
    Vector3 attackerPos;
    int atk;
    Vector3 targetPos;
    public float moveSpeed;
    public float atkRange;
    


    private void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        // Ÿ���� null�� �Ǿ��� �� ����� ��쿡�� �ٷ� ������� �༭ update�� InitTarget�� �־ �ٷιٷ� �ֽ�ȭ�ص� ���������
        // �ü��� ������� ���� �����տ� ���󰡴� ��쿣 �ٷδ������ �ټ��ִ°� �ƴϰ� ȭ���� Ÿ�ٿ� �������� �� ������� �Ծ����
        // �׷��� ȭ���� ���ư��� ���߿� Ÿ���� �׾ null�� �� �� �� ������ ���з� ó���� Destroy��
        if (target != null) // Ÿ���� ���� ���� 
        {            
            targetPos = target.transform.position;
            MoveAttackToTarget();            
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    public void MoveAttackToTarget()
    {        
        Vector3 tempPos = new Vector3(targetPos.x, targetPos.y, transform.position.z) - transform.position;
        transform.forward = tempPos;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed);
        float targetDis = Vector3.Distance(transform.position, targetPos); // ȭ��� Ÿ�ٰ��� �Ÿ�, tempPos�� 0�϶��� �ᵵ�ɵ�
        float towerDis = Vector3.Distance(transform.position, attackerPos); // ȭ��� ȭ���� �� Ÿ������ �Ÿ�
        if (targetDis == 0 || towerDis >= atkRange) // distance�� �ִ������ ����ų�, Ÿ�ٰ��� �Ÿ��� 0�̵Ǹ� 
        {
            if(targetDis == 0)
            {
                target.GetComponent<Monster>().TakeDamage(atk);
            }            
            Destroy(gameObject);
        }        
    }

    public void SetTarget(GameObject target, Vector3 attackerPos, int atk)
    {
        this.target = target;
        this.attackerPos = attackerPos;
        this.atk = atk;
    }   
}
