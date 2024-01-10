using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RangeObj : MonoBehaviour
{


    // �Ϻη� ū�ɷ� ���� ���� �̰� ���ϲ���
    [SerializeField]
    GameObject material;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    GameObject destroyEffect;

    GameObject target;
    Soldier attacker;

    [SerializeField]
    float tempRange;

    [SerializeField]
    int damage;

    public Vector3 targetPosition;


    // ������Ʈ�� ���ݰ� ���ÿ� ������ٸ� tempRange ������ ũ�⸦ �ٿ� �� ��
    protected bool MoveTarget(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position , target.position , moveSpeed);
        
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance >= tempRange)
            return false;

        

        return true;
    }


    // ���Ÿ� ������Ʈ�� maxDistance ��ŭ�� ���̺��� �������ٸ� ���� �����Ͽ�
    // ���� �Լ��� ȣ�� �� �� �ְԲ� �ϰ� ����
    private bool MoveTarget(Transform target , float maxDistance)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed);
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance >= maxDistance)
            return false;
        
        return true;
    }

    private bool MoveObj()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition , moveSpeed);

        if (targetPosition == Vector3.zero)
        {

            if (destroyEffect != null)
            {
                GameObject tempObj = Instantiate(destroyEffect);
                //tempObj.GetComponent<AP_Projectiles>().atk = attacker.status.atk;
            }
            Destroy(gameObject);
            
        }
            

        if (Vector3.Distance(targetPosition,transform.position) <= tempRange)
            return true;

        return false;
    }

    public void SetTarget(GameObject tartget , Soldier attacker)
    {
        this.attacker = attacker;
        this.target = tartget;
    }

    public void SetTarget(Vector3 targetPos , Soldier attacker)
    {
        this.targetPosition = targetPos;
        this.attacker = attacker;
    }


    // Start is called before the first frame update
    void Start()
    {
        tempRange = 0.5f;
        moveSpeed = 0.2f;
    }


    private void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }


        if (target == null)
        {
            if (MoveObj())
            {
                if (destroyEffect != null)
                {
                    Instantiate(destroyEffect, transform.position , transform.rotation);
                }
                Destroy(gameObject);
            }
                

        }
        else 
        {
            targetPosition = target.transform.position;

            if (MoveTarget(target.transform))
            {

                if (destroyEffect != null)
                    Instantiate(destroyEffect, transform.position, transform.rotation);


                //target.GetComponent<Monster>().TakeDamage(attacker.GetDamage());
                target.GetComponent<Monster>().TakeDamage(damage);
                Destroy(gameObject);
            }

        }

        transform.LookAt(targetPosition);


    }

}
