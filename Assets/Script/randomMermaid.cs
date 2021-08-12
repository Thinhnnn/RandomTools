using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomMermaid : MonoBehaviour
{
    [SerializeField] Sprite[] staffs, heads, tails, chests, bodys, hands;

    [SerializeField] Image staff, head, tail, chest, body, hand;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doRandom()
    {
        randomItem(staffs, staff);
        randomItem(heads, head);
        randomItem(tails, tail);
        randomItem(chests, chest);
        randomItem(bodys, body);
        randomItem(hands, hand);
    }

    public void randomItem(Sprite[] listImage, Image obj)
    {
        int i = Random.Range(0, listImage.Length);
        obj.sprite = listImage[i];
    }
}
