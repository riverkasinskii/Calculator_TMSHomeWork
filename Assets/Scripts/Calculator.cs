using System;
using TMPro;
using UnityEngine;

public enum Operations
{
    Add,
    Subtract,
    Multiply,
    Divide
}

public class Calculator : MonoBehaviour
{    
    [SerializeField] private TMP_InputField firstValue;
    [SerializeField] private TMP_InputField secondValue;
    private Operations operations;    
    
    public void Result(string enumStr)
    {
        operations = (Operations)Enum.Parse(typeof(Operations), enumStr);
        print(Calculate(operations, firstValue, secondValue));
    }        

    private float Calculate(Operations operations, TMP_InputField firstInput,
        TMP_InputField secondInput)
    {
        InputParse(firstInput, secondInput, out float firstResult, out float secondResult);

        return operations switch
        {
            Operations.Add => Add(firstResult, secondResult),
            Operations.Subtract => Subtract(firstResult, secondResult),
            Operations.Multiply => Multiply(firstResult, secondResult),
            Operations.Divide => Divide(firstResult, secondResult),
            _ => throw new NotImplementedException("Unknown operation!"),
        };
    }

    private static void InputParse(TMP_InputField firstInput, TMP_InputField secondInput,
        out float firstResult, out float secondResult)
    {        
        float.TryParse(firstInput.text, out firstResult);
        float.TryParse(secondInput.text, out secondResult);
    }

    private float Add (float firstValue, float secondValue)
    {        
        return firstValue + secondValue;
    }

    private float Multiply(float firstValue, float secondValue)
    {
        return firstValue * secondValue;
    }

    private float Divide(float firstValue, float secondValue)
    {
        if (secondValue == 0)
        {
            throw new NotImplementedException("Division by zero is impossible!");
        }
        return firstValue / secondValue;
    }

    private float Subtract(float firstValue, float secondValue)
    {
        return firstValue - secondValue;
    }
}
