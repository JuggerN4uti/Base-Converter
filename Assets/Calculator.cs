using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    public Button UpCBase, DownCBase;
    public TMPro.TextMeshProUGUI OriginalNumberText, CalculatedNumberText, CBaseText;

    public int[] ODigits, CDigits;
    public int ODigitCount, CDigitCount, CBase;
    public int originalNumber;
    public string calculatedNumber;
    int tempi;
    float temp;

    void Start()
    {
        UpdateBase();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
            WriteDigit(0);
        if (Input.GetKeyDown(KeyCode.Alpha1))
            WriteDigit(1);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            WriteDigit(2);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            WriteDigit(3);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            WriteDigit(4);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            WriteDigit(5);
        if (Input.GetKeyDown(KeyCode.Alpha6))
            WriteDigit(6);
        if (Input.GetKeyDown(KeyCode.Alpha7))
            WriteDigit(7);
        if (Input.GetKeyDown(KeyCode.Alpha8))
            WriteDigit(8);
        if (Input.GetKeyDown(KeyCode.Alpha9))
            WriteDigit(9);
    }

    void WriteDigit(int digit)
    {
        if (ODigitCount < 9)
        {
            ODigits[ODigitCount] = digit;
            ODigitCount++;
            UpdateOriginalNumber();
        }
    }

    void UpdateOriginalNumber()
    {
        temp = 0;
        for (int i = 0; i < ODigitCount; i++)
        {
            if (i + 1 == ODigitCount) temp += ODigits[i];
            else temp += ODigits[i] * Mathf.Pow(10f, ODigitCount - (i + 1));
        }
        originalNumber = Mathf.FloorToInt(temp);
        OriginalNumberText.text = originalNumber.ToString("0");
        //OriginalNumberText.text
    }

    public void UpdateBase()
    {
        CBaseText.text = CBase.ToString("0");

        if (CBase < 10) UpCBase.interactable = true;
        else UpCBase.interactable = false;

        if (CBase > 2) DownCBase.interactable = true;
        else DownCBase.interactable = false;
    }

    public void IncreaseCBase()
    {
        CBase++;
        UpdateBase();
    }

    public void DecreaseCBase()
    {
        CBase--;
        UpdateBase();
    }

    public void Calculate()
    {
        tempi = originalNumber;
        CDigitCount = 0;
        while (tempi >= CBase)
        {
            CDigits[CDigitCount] = tempi % CBase;
            CDigitCount++;
            tempi /= CBase;
        }
        CDigits[CDigitCount] = tempi;

        UpdateCalculatedNumber();
    }

    public void UpdateCalculatedNumber()
    {
        calculatedNumber = "";
        for (int i = CDigitCount; i >= 0; i--)
        {
            calculatedNumber += CDigits[i].ToString("");
        }
        CalculatedNumberText.text = calculatedNumber;
    }

    public void Reset()
    {
        ODigitCount = 0;
        for (int i = 0; i < 9; i++)
        {
            ODigits[i] = 0;
        }
        OriginalNumberText.text = "0";
    }
}
