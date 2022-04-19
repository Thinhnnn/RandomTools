using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomTool15042022 : MonoBehaviour
{
    [SerializeField] TMP_InputField tmpType;
    [SerializeField] TMP_InputField tmpAmount;
    [SerializeField] TextMeshProUGUI tmpName;
    int type = 0;
    int amount = 0;

    [SerializeField] List<RandomItem> characterLst;
    [SerializeField] List<GameObject> subCharacterLst;

    [SerializeField] float time;
    [SerializeField] Button btnRender;

    Coroutine loopCoroutine;

    public void DoLoopRender()
    {
        int.TryParse(tmpType.text, out type);
        int.TryParse(tmpAmount.text, out amount);
        if (type >= 0 && type < characterLst.Count)
        {
            if (amount > 0)
            {
                ShowCharacter(type);
                btnRender.interactable = false;
                loopCoroutine = StartCoroutine(IELoopRender());
            }
        }
    }

    IEnumerator IELoopRender()
    {
        var imageName = characterLst[type].DoRandom();
        TakeScreenShot.TakeScreenshot_Static(1920, 1080, imageName);
        amount--;
        tmpName.text = imageName;
        tmpType.text = type.ToString();
        tmpAmount.text = amount.ToString();
        yield return new WaitForSeconds(time);
        if (amount > 0)
        {
            loopCoroutine = StartCoroutine(IELoopRender());
        }
        else
        {
            btnRender.interactable = true;
        }
    }

    void ShowCharacter(int characterIndex)
    {
        if (!characterLst[characterIndex].gameObject.activeSelf)
        {
            characterLst.ForEach(x => x.gameObject.SetActive(false));
            subCharacterLst.ForEach(x => x.SetActive(false));
            characterLst[characterIndex].gameObject.SetActive(true);
            subCharacterLst[characterIndex].SetActive(true);
        }
    }
}

[System.Serializable]
public class CharacterPart
{
    public string Name;
    public List<Sprite> spriteLst;
}

[System.Serializable]
public class ExtraPart
{
    public Image extraImage;
    public Image cloneExtraImage;
    public Sprite extraSprite;
    public int partIndex;
    public int randomValue;
}
