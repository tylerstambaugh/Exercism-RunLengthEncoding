

//Console.WriteLine(RunLengthEncoding.Encode("AABBBCCCC"));
//Console.WriteLine(RunLengthEncoding.Encode("XYZ"));

// Console.WriteLine(RunLengthEncoding.Decode("2A3B4C"));
Console.WriteLine(RunLengthEncoding.Decode("12WB12W3B24WB"));

Console.ReadLine();

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        string encodedString = "";
        int numChars = 1;
        int index = 0;
        int inputLength = input.Length;

        if (input == "")
        {
            return input;
        }
        else
        {
            while (index < inputLength)
            {
                char c = input[index];
                if (index < inputLength - 1)
                {
                    if (c == input[index + 1])
                    {
                        numChars++;
                        index++;
                    }

                    else if (c != input[index + 1] && numChars > 1)
                    {
                        encodedString += numChars + c.ToString();
                        numChars = 1;
                        index++;
                    }
                    else
                    {
                        encodedString += c.ToString();
                        index++;
                    }
                }
                else if (index == input.Length - 1 && numChars > 1)
                {
                    encodedString += numChars + c.ToString();
                    index++;
                    numChars = 1;
                }
                else if (index == input.Length - 1 && numChars == 1)
                {
                    encodedString += c.ToString();
                    index++;
                    numChars = 1;
                }
            }
            return encodedString;
        }
    }

   
    public static string Decode(string input)
    {
        string decodedString = "";
        string inputTrimmed = input.Trim();
        int inputLength = inputTrimmed.Length;

        //empty string check
        if(input == "")
        {
            decodedString = "";
        }

        //main loop through encoded string
        for(int i = 0; i < inputLength; i++)
        {
            bool isDigit = Char.IsDigit(inputTrimmed[i]);
            string countOfEncoding = "";

            //check to see if current char and following char(s) are digits
            while(isDigit && i < inputLength)
            {
                countOfEncoding += inputTrimmed[i];
                i++;
                isDigit = Char.IsDigit(inputTrimmed[i]);
            }

            //if countOfEncoding is empty, set to 1
            if(countOfEncoding == "")
            {
                countOfEncoding = "1";
            }

            //add correct number of chars to decoded string
            for(int j = 1; j <= Int16.Parse(countOfEncoding); j++)
            {
                decodedString += inputTrimmed[i];
            }

            //advance index correct number of spaces
            // i + countOfEncoding;
        }

        return decodedString;
    }
    
    
    //public static string Decode(string input)
    //{
    //    string decodedString = "";
    //    string inputTrimmed = input.Trim();
    //    int inputLength = inputTrimmed.Length;

    //    if (input == "")
    //    {
    //        decodedString = "";
    //    }

    //    for (int i = 0; i < inputTrimmed.Length; i++)
    //    {
    //        char currentChar = input[i];
            
    //        int countOfEncoding = 1;
            
    //        bool currentCharIsDigit = Char.IsDigit(currentChar);
    //        bool nextCharIsDigit = false;

    //        if (currentCharIsDigit)
    //        {
    //            countOfEncoding = Int16.Parse(currentChar.ToString());
    //        }

    //        if (i < inputLength - 1)
    //        {
    //            nextCharIsDigit = Char.IsDigit(input[i + 1]);
    //            if (nextCharIsDigit && !currentCharIsDigit)
    //            {
    //                string num = countOfEncoding.ToString();
    //                num += Int16.Parse(input[i + 1].ToString());
    //                countOfEncoding = Int16.Parse(num);
    //                i++;
    //            }
    //        }

    //        if (!Char.IsDigit(currentChar) && countOfEncoding == 1)
    //        {
    //            decodedString += currentChar;
    //        }

    //        if (i < inputLength - 1)
    //        {
    //            if (!Char.IsDigit(input[i + 1]) && countOfEncoding > 1)
    //            {
    //                string decodedChars = "";
    //                for (int j = countOfEncoding; j > 0; j--)
    //                {
    //                    decodedChars += input[i + 1].ToString();
    //                }
    //                i++;
    //                decodedString += decodedChars;
    //            }
    //        }
    //    }
    //    return decodedString;
    //}
}
