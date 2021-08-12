using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class changeCharacter : MonoBehaviour
{
    [SerializeField] GameObject[] characters;

    [SerializeField] GameObject[] subCharacters;

    [SerializeField] TextMeshProUGUI input;

    [SerializeField] TMP_InputField ammountLoop;
    // Start is called before the first frame update
    [SerializeField] int index;
    void Start()
    {
        showCharacter(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showCharacter(int index)
    {
        this.index = index;
        foreach(GameObject charr in characters)
        {
            charr.SetActive(false);
        }
        foreach (GameObject subcharr in subCharacters)
        {
            subcharr.SetActive(false);
        }
        characters[index].SetActive(true);
        subCharacters[index].SetActive(true);
    }

    public void getByID()
    {
        string inputValue = input.text;
        if (inputValue.Length >= 33)
        {
            int[] extraPoint = { 0, 0, 0, 0, 0 };
            int[] bodyItem = { 0, 0, 0, 0, 0, 0 };
            int[] skills = { 1, 1, 1, 1 };
            int tempIndex = 0;
            for (int i = 0; i < 6; i++)
            {
                bodyItem[i] = int.Parse(inputValue.Substring(i, 1));
            }
            for (int i = 6; i < 19; i += 3)
            {
                extraPoint[tempIndex] = int.Parse(inputValue.Substring(i, 3));
                tempIndex++;
            }
            tempIndex = 0;
            for (int i = 21; i < 31; i += 3)
            {
                skills[tempIndex] = int.Parse(inputValue.Substring(i, 3));
                tempIndex++;
            }
            characters[index].GetComponent<randomCharacters>().setValueByID(bodyItem, extraPoint, skills);
        }    
    }

    public void getByName()
    {
        string inputValue = input.text;
        int[] bodyItem = { 0, 0, 0, 0, 0, 0 };
        int tempIndex = 0; 
        for (int i = 0; i < 6; i++)
        {
            bodyItem[5-i] = int.Parse(inputValue.Substring(inputValue.Length - 2 - i * 3, 1));
        }
        if (inputValue.Substring(0, 6) == "dragon")
        {
            //Debug.Log(inputValue.Substring(0, 6));
            tempIndex = 0;
        }
        else if (inputValue.Substring(0, 7) == "mermaid")
        {
            //Debug.Log(inputValue.Substring(0, 7));
            tempIndex = 1;
        }
        else if (inputValue.Substring(0, 7) == "ancient")
        {
            //Debug.Log(inputValue.Substring(0, 7));
            tempIndex = 2;
        }
        else if (inputValue.Substring(0, 6) == "shadow")
        {
            //Debug.Log(inputValue.Substring(0, 6));
            tempIndex = 3;
        }
        showCharacter(tempIndex);
        characters[tempIndex].GetComponent<randomCharacters>().setValueByName(bodyItem);

        //characters[index].GetComponent<randomCharacters>().setValueByID(bodyItem, extraPoint, skills);

    }

    public void doLoopRender()
    {
        //Debug.Log(ammountLoop.text);
        int count = int.Parse(ammountLoop.text.Trim());
        ammountLoop.enabled = false;
        //int count = 10;
        StartCoroutine(render(count));
    }

    IEnumerator render(int count)
    {
        characters[index].GetComponent<randomCharacters>().doRandom();
        count--;
        ammountLoop.text = count.ToString();
        yield return new WaitForSeconds(0.2f);
        if (count > 0)
        {
            StartCoroutine(render(count));
        }
        else
        {
            ammountLoop.enabled = true;
        }
    }
}
