using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BoardScript : MonoBehaviour
{
    [SerializeField]
    private GameObject stageDisplayPrefab;

    [SerializeField]
    private TextMeshProUGUI curStageText;

    [SerializeField]
    private TextMeshProUGUI orderText;

    [SerializeField]
    private StageController stageController;

    [SerializeField]
    private ScrollRect scrollRect;

    [SerializeField]
    private RectTransform scrollContainer;

    private Stage currStage = null;

    private float stageDisplayHeight = 0f;

    private float scrollInitHeight = 0f;

    private void Awake()
    {
        stageController.OnStageSwitch += OnStageSwitch;
        stageDisplayHeight = (stageDisplayPrefab.transform as RectTransform).sizeDelta.y;
        scrollInitHeight = scrollContainer.sizeDelta.y;
    }

    private void OnDestroy()
    {
        stageController.OnStageSwitch -= OnStageSwitch;
    }

    private void ResetScrollPosition()
    {
        float t = scrollContainer.childCount * stageDisplayHeight;
        if (t > scrollInitHeight)
        {
            if (t > scrollContainer.sizeDelta.y)
            {
                scrollContainer.sizeDelta = new Vector2(scrollContainer.sizeDelta.x, t);
            }
            scrollContainer.localPosition = new Vector3(0f, (scrollInitHeight - t) / 2f, 0f);
        }
        else
        {
            scrollContainer.localPosition = Vector3.zero;
        }
    }

    private void OnStageSwitch(Stage stage)
    {
        if (currStage != null)
        {
            StageDisplay sd = Instantiate(stageDisplayPrefab, scrollContainer).GetComponent<StageDisplay>();
            sd.Init(currStage);
            ResetScrollPosition();
        }
        if (stage == null)
        {
            curStageText.text = "Нет задания";
            orderText.text = "";
            currStage = stage;
        }
        else
        {
            curStageText.text = stage.description;
            orderText.text = stage.ID.ToString();
            currStage = stage;
        }        
    }
}
