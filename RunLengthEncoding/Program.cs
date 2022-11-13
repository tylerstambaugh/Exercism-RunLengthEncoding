
// https://exercism.org/tracks/csharp/exercises/run-length-encoding

//Console.WriteLine(RunLengthEncoding.Encode("AABBBCCCC"));
//Console.WriteLine(RunLengthEncoding.Encode("XYZ"));

// Console.WriteLine(RunLengthEncoding.Decode("2A3B4C"));
//Console.WriteLine(RunLengthEncoding.Decode("12WB12W3B24WB"));

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
        int inputLength = input.Length;

        //empty string check
        if(input == "")
        {
            decodedString = "";
        }

        //main loop through encoded string
        for(int i = 0; i < inputLength; i++)
        {
            bool isDigit = Char.IsDigit(input[i]);
            string countOfEncoding = "";

            //check to see if current char and following char(s) are digits
            while(isDigit && i < inputLength)
            {
                countOfEncoding += input[i];
                i++;
                isDigit = Char.IsDigit(input[i]);
            }

            //if countOfEncoding is empty, set to 1
            if(countOfEncoding == "")
            {
                countOfEncoding = "1";
            }

            //add correct number of chars to decoded string
            for(int j = 1; j <= Int16.Parse(countOfEncoding); j++)
            {
                decodedString += input[i];
            }

            //advance index correct number of spaces
            // i + countOfEncoding;
        }

        return decodedString;
    }
    

}
