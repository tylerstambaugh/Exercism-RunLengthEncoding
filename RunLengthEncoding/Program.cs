

//Console.WriteLine(RunLengthEncoding.Encode("AABBBCCCC"));
//Console.WriteLine(RunLengthEncoding.Encode("XYZ"));

// Console.WriteLine(RunLengthEncoding.Decode("2A3B4C"));
Console.WriteLine(RunLengthEncoding.Decode("XYZ"));

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
        bool isDigit;
        
        if (input == "")
        {
            decodedString = "";
        }

        for (int i = 0; i < inputTrimmed.Length; i++)
        {
            char c = input[i];
            int countOfDigits = 1;
            int inputLength = inputTrimmed.Length;
            if (Char.IsDigit(c))
            {
                countOfDigits = Int16.Parse(c.ToString());
            }

            if (!Char.IsDigit(c) && countOfDigits == 1)
            {
                decodedString += c;
            }

            if (i < inputLength - 1)
            {
                if (!Char.IsDigit(input[i + 1]) && countOfDigits > 1)
                {
                    string decodedChars = "";
                    for (int j = countOfDigits; j > 0; j--)
                    {
                        decodedChars += input[i + 1].ToString();
                    }
                    i++;
                    decodedString += decodedChars;
                }
            }

        }

        return decodedString;
    }
}
