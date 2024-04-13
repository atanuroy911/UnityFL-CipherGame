using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CaesarEncoding : MonoBehaviour
{
    public TextMeshProUGUI InputTextBox;
    private string InputText;
    public TextMeshProUGUI OutputTextBox;
    private string OutputText = "";
    public TextMeshProUGUI ShiftText;
    private int Shift;
    [SerializeField] private bool Encrypting;
    [SerializeField] private bool Alter;
    public bool TextActive;
    private string AlterCipher = "MAKERNDOYBCFGHIJLPQRSTUVWXZ";

    // Start is called before the first frame update
    void Start()
    {
        InputText = InputTextBox.text;
    }

    // Update is called once per frame
    void Update()
    {
        if (TextActive)
        {
            OutputText = "";
            int.TryParse(ShiftText.text, out Shift);

            if (Alter)
            {
                foreach (char ch in InputText)
                {
                    int TempVal = 0;
                    string TempStr;

                    if (ch == ' ')
                    {
                        TempStr = " ";
                    }
                    else if (Encrypting)
                    {
                        TempVal = AlterCipher.IndexOf(ch) + Shift;

                        if (TempVal > 25)
                        {
                            TempVal = TempVal - 26;
                        }
                    }
                    else
                    {
                        TempVal = AlterCipher.IndexOf(ch) - Shift;

                        if (TempVal < 0)
                        {
                            TempVal = TempVal + 26;
                        }
                    }

                    TempStr = AlterCipher.Substring(TempVal, 1);
                    OutputText = OutputText + TempVal;
                }
            }
            else
            {
                foreach (char ch in InputText)
                {
                    int ASCIIVal = (int)ch;
                    int TempVal;

                    if (ASCIIVal == 32)
                    {
                        TempVal = 32;
                    }
                    else if (Encrypting)
                    {
                        TempVal = ASCIIVal + Shift;

                        if (TempVal > 90)
                        {
                            TempVal = TempVal - 26;
                        }
                    }
                    else
                    {
                        TempVal = ASCIIVal - Shift;

                        if (TempVal < 65)
                        {
                        TempVal = TempVal + 26;
                        }
                    }

                    OutputText = OutputText + (char)TempVal;
                }
            }
            

            OutputTextBox.text = OutputText;
            Debug.Log(InputText + " : " + Shift + " : " + OutputText);
        }
    }
}
