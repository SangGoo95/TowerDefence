using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MonsterSpawn : MonoBehaviour
{
    //�����ð� ����
    public float spawnDelay;

    // ������ ����
    public List<int> monsterCountList;

    // ���͸���Ʈ ����
    // ������ ����
    public List<GameObject> monsterList; // = new List<GameObject>();

    //�̵�����Ʈ ����
    public List<Transform> checkPoint;
    public static List<Transform> CheckPoint = null;

    public List<Vector3> angleList;

    //���� ����Ʈ�� �ִ� ���Ͱ� �� ��ȯ�ϰ� 0�� ����
    int currentIndex = 0;

    //����Ʈ����
    public GameObject spawn;
    public GameObject spawnObj;


    void Start()
    {
        //������ġ�� �ױ׷� ����
        spawn = GameObject.FindWithTag("spawn");

        // ���� �����̿� ������ ���ϱ�, ������ �������� ���߿� �����������
        spawnDelay = 1.0f;

        CheckPoint = checkPoint;
        //���͸���Ʈ�� �ִ� ���͸� �����ð���ŭ ������Ű��
        StartCoroutine(MonsterSpawnCo(0));
    }


    // ���� �ν��Ͻ� ������
    // �� ���Ϳ��� üũ����Ʈ�� ����Ʈ�� ������ �ְ�
    // ���⿡�� üũ����Ʈ�� ���� ���� �Ѱ���
    IEnumerator MonsterSpawnCo(int waveRound)
    {
        // true = ����� �������� ��
        while (monsterList.Count > waveRound)
        {
            // ���� ��ȯ�� ���� �� < �� ��ȯ�� ���� ��
            while(currentIndex < monsterCountList[waveRound])
            {
                // ���� ��ȯ ����
                yield return new WaitForSeconds(spawnDelay);
                //����Ʈ ������ ���� ����Ʈ�� �ִ� ���͸� ��ȯ��Ű��, spawn�� ��ġ�� �޾ƿͼ� ��ȯ
                Vector3 createPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                spawnObj = Instantiate(monsterList[waveRound]);
                spawnObj.transform.position = createPos;
                spawnObj.transform.LookAt(checkPoint[0]);
                spawnObj.transform.localEulerAngles = new Vector3(spawnObj.transform.localEulerAngles.x, 90, -90);
                spawnObj.GetComponent<Monster>().checkPoint = checkPoint;
                currentIndex++;
            }
            // ���ͼ� �ʱ�ȭ
            currentIndex = 0;
            // ���� ����
            waveRound += 1;
            // ���� ���̺���� �ɸ��� �ð�
            yield return new WaitForSeconds(5.0f);
        }
    }
}
