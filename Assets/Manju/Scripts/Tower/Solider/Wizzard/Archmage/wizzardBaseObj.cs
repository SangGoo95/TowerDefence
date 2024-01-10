using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizzardBaseObj : MonoBehaviour
{
    int atk;
    [SerializeField] float atkAmount;

    // �ݸ��� �浹�̾���ϴϱ� ������ isTrigger�� ����������� �׷��� Ʈ���ŷ� �ص������� �־���? ����� �̰Ž�ų�� Base�� �ٽø����

    private void OnParticleSystemStopped() // StopAction�� �ݹ����� ���� �� ȣ��, �׳� StopAction Destroy�� �����ؼ� �ı���Ŵ
    {
        Destroy(gameObject);
    }
    

    private void OnParticleCollision(GameObject other)
    {        
        if (other.TryGetComponent<Monster>(out var monster))
        {                
            monster.TakeDamage(atk);            
        }
    }    

    public void SetAtk(int atk)
    {
        // this.atk = (int)(atkAmount * atk); 
        this.atk = atk;
    }
}
