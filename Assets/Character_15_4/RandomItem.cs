using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomItem : MonoBehaviour
{
    [SerializeField] public List<CharacterPart> characterPart;
    [SerializeField] public List<Image> imagePart;
    [SerializeField] public List<Image> cloneImagePart;
    [SerializeField] public List<ExtraPart> extraPart;

    public virtual string DoRandom()
    {
        string name = this.gameObject.name;
        foreach(var extra in extraPart)
        {
            extra.extraImage.gameObject.SetActive(false);
            extra.cloneExtraImage.gameObject.SetActive(false);
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
            name += "_" + characterPart[i].Name + randomValue;
        }
        return name;
        //TakeScreenShot.TakeScreenshot_Static(1920, 1080, finalCharacter.id);
    }

    public ExtraPart ExtraPartFound(int partIndex, int randonValue)
    {
        return extraPart.Find(x => x.partIndex == partIndex && x.randomValue == randonValue);
    }

    //private void Update()
    //{
    //    if (this.gameObject.activeSelf)
    //    {
    //        if (Input.GetKeyDown(KeyCode.Q))
    //        {
    //            DoRandom();
    //        }
    //    }
    //}
}
