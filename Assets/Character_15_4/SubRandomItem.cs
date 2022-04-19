using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubRandomItem : RandomItem
{
    [SerializeField] public List<ExtraPart> subExtraPart;

    public override string DoRandom()
    {
        string name = this.gameObject.name;
        foreach (var extra in extraPart)
        {
            extra.extraImage.gameObject.SetActive(false);
            extra.cloneExtraImage.gameObject.SetActive(false);
        }
        foreach (var subExtra in subExtraPart)
        {
            subExtra.extraImage.gameObject.SetActive(false);
            subExtra.cloneExtraImage.gameObject.SetActive(false);
        }
        int randomValue = 0;
        for (int i = 0; i < characterPart.Count; i++)
        {
            randomValue = Random.Range(0, characterPart[i].spriteLst.Count);
            imagePart[i].sprite = characterPart[i].spriteLst[randomValue];
            cloneImagePart[i].sprite = imagePart[i].sprite;
            var extraPartFound = ExtraPartFound(i, randomValue);
            if (extraPartFound != null)
            {
                extraPartFound.extraImage.sprite = extraPartFound.extraSprite;
                extraPartFound.cloneExtraImage.sprite = extraPartFound.extraSprite;
                extraPartFound.extraImage.gameObject.SetActive(true);
                extraPartFound.cloneExtraImage.gameObject.SetActive(true);
            }
            var subExtraPartFound = SubExtraPartFound(i, randomValue);
            if (subExtraPartFound != null)
            {
                subExtraPartFound.extraImage.sprite = subExtraPartFound.extraSprite;
                subExtraPartFound.cloneExtraImage.sprite = subExtraPartFound.extraSprite;
                subExtraPartFound.extraImage.gameObject.SetActive(true);
                subExtraPartFound.cloneExtraImage.gameObject.SetActive(true);
            }
            name += "_" + characterPart[i].Name + randomValue;
        }
        return name;
    }

    public ExtraPart SubExtraPartFound(int partIndex, int randonValue)
    {
        return subExtraPart.Find(x => x.partIndex == partIndex && x.randomValue == randonValue);
    }
}
