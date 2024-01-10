using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


//230905 ��ȣ�� comment
//  ���� uimanager�� ������ �ִ� prefab�� ���� �Ƹ� script�� �޾Ƽ� �׷� �� 
//  UI manager�� ��� ���̰� �̹� ���� Ʋ�� ���� ������ �ʿ��� ����
//  Ui manager ���� ���� ���� ���� �ΰ� ���� �ʿ� ���


public class UiManager : MonoBehaviour
{
    public List<GameObject> towerJobBtnList;
    public List<GameObject> towerRotationBtnList;
    public List<GameObject> towerOptionBtnList;
    public List<GameObject> gameOptionBtnList;

    public TextMeshProUGUI falseMessage;
    public TextMeshProUGUI skillOptionText;
    public TextMeshProUGUI skillDamageText;

    public static UiManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<UiManager>();
            }
            return instance;
        }
    }
    private static UiManager instance;

    [SerializeField] List<TextMeshProUGUI> textMeshProUGUI;

    public GameObject selectTileUiObj;
    public GameObject currentSelectTile;

    private void Update()
    {
        textMeshProUGUI[0].text = Player.Instance.Life.ToString();
        textMeshProUGUI[1].text = Player.Instance.Cost.ToString();
        textMeshProUGUI[2].text = Player.Instance.population.ToString() + " / " + Player.Instance.maxPopulation.ToString();
    }

    public void TileSelectUi(bool isShow)
    {
        if(currentSelectTile != null)
        {
            Destroy(currentSelectTile);
        }

        if(isShow)
        {
            currentSelectTile = Instantiate(selectTileUiObj, TowerManager.Instance.selectTile.transform.position, Quaternion.identity);
            currentSelectTile.transform.position += Vector3.back * 3;
        }
    }

    public void TowerJobSelectUi(bool isShow)
    {
        towerJobBtnList[0].transform.parent.gameObject.SetActive(isShow);
        TileSelectUi(isShow);
    }

    public void TowerRotationSelectUi(bool isShow)
    {

        TowerJobSelectUi(false);
        towerRotationBtnList[0].transform.parent.position = CurrentUiPosition();
        for (int i = 0; i < towerRotationBtnList.Count;i++)
        {
            towerRotationBtnList[i].SetActive(isShow);
        }
    }

    public void TowerOptionUi(bool isShow)
    {
        towerOptionBtnList[0].transform.parent.position = CurrentUiPosition();
        int j = 0;
        if (isShow)
        {
            // Ÿ���ɼ� ui�� ������ ���� Ÿ���� ���� �Ҷ��� ������
            // �׷��Ƿ� isShow�� true�� ���� towerObj�� null�� ���� �ʴ´�
            // ���� if���� ���� ���ԵǸ� Ÿ���ɼ��� ���� ��쿡�� towerObj�� ���������� �Ǵ��ϱ� ������
            // �η��۷��� ������ �߻� �� �� �ִ�.
            Tower selectTower = TowerManager.Instance.selectTile.towerObj.GetComponent<Tower>();
            if (selectTower.status.towerSkills.Count > 0)
            {
                Skill towerSkill = selectTower.status.towerSkills[0];

                towerOptionBtnList[2].GetComponent<Image>().sprite = towerSkill.skillImage;
                skillOptionText.text = towerSkill.skillOption;
                skillDamageText.text = towerSkill.skillDamageText;
            }
            else
            {
                towerOptionBtnList[2].GetComponent<Image>().sprite = selectTower.GetComponent<Farmer>().skillImage;
                skillOptionText.text = "������ ��ȭ�� ä���մϴ�.";
                skillDamageText.text = "�α����� �÷��ݴϴ�.";
            }

            if (selectTower.nextLevelTower == null)
            {
                j = 1;
            }
        }
        for (int i = j; i < towerOptionBtnList.Count; i++)
        {
            towerOptionBtnList[i].SetActive(isShow);
        }
    }

    // ����� �����̶� �����Ͻ����� �ϴ� ui �߰�
    public void GameOptionUi(bool isShow)
    {
        if (isShow)
        {
            gameOptionBtnList[0].SetActive(isShow);
            Time.timeScale = 0.0f;
        }
        else
        {
            gameOptionBtnList[0].SetActive(isShow);
            Time.timeScale = 1.0f;
        }
    }

    Vector3 CurrentUiPosition()
    {
        Vector3 tempPos = TowerManager.Instance.selectTile.transform.position;
        Vector3 uiScreenPos = Camera.main.WorldToScreenPoint(tempPos);

        return uiScreenPos;
    }

    public IEnumerator FalseMessageCo(string msg)
    {
        falseMessage.transform.parent.gameObject.SetActive(true);
        falseMessage.text = msg;
        yield return new WaitForSeconds(0.8f);
        falseMessage.transform.parent.gameObject.SetActive(false);
    }
}
