using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOptionBtnController : MonoBehaviour
{
    public void OptionSelect(bool isShow)
    {
        // UiManager�� �ɼ� Ui ���� ��� ȣ��
        SceneUiManager.Instance.GameOptionUi(isShow);
    }

    public void ExitSelect(bool isShow)
    {
        // UiManager�� ���� Ui ���� ��� ȣ��
        SceneUiManager.Instance.GameExitUi(isShow);
    }
}
