using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    public static void Main()
    {
        string[] parentheses = { "([", "([)]", "[]", "([])", "({})[]{}(((())))" };

        BracketMatch(parentheses);
    }

    public static void BracketMatch(string[] inputs)
    {
        foreach (var input in inputs)
        {
            // Regex nesnesi oluşturup eşleşmesini beklediğimiz parantez çiftlerini pattern olarak tanımladık
            Regex regex = new Regex(@"\(\)|\[\]|\{\}");

            // input'u tutan geçici inputumuz 
            string temporaryInput = null;
            
            string currentInput = input; // Mevcut inputu saklayan değişken

            // İki değer de eşit olana kadar döngü devam edecek 
            while (currentInput != temporaryInput)
            {
                temporaryInput = currentInput;

                // input string içerisinde eşleşen parantez çiftlerini bulur regex patterne göre
                Match match = regex.Match(currentInput);
                while (match.Success)
                {
                    currentInput = currentInput.Remove(match.Index, 2); // Eşleşen parantezlerin her ikisini de inputtan çıkarır
                    match = regex.Match(currentInput);
                }
            }

            // İnput değeri boş olursa tüm parantez çiftleri eşleşmiş olduğu anlamına gelir.
            bool result = string.IsNullOrEmpty(currentInput) ? true : false;

            Console.WriteLine(input + " == " + result);
        }
    }


}