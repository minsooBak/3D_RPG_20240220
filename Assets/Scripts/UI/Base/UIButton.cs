using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIButton : UIBase
{
    public void Init(UnityAction action, string text)
    {
        GetComponent<Button>().onClick.AddListener(action);
        GetComponentInChildren<TextMeshProUGUI>().text = text;
    }
}
