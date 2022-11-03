

Console.WriteLine(RunLengthEncoding.Encode("AABBBCCCC"));
Console.ReadLine();

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        string encodedString = "";
        int numChars = 1;
        int index = 0;
        int inputLength = input.Length;

        while(index <= input.Length)
        {
            char c = input[index];
            if (index < inputLength)
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
            }

            else if (index == input.Length)
            {
                encodedString += c.ToString();
                index++;
                numChars = 1;
            }
        }

        return encodedString;
    }

    public static string Decode(string input)
    {
        string decodedString = input;
        return decodedString;
    }
}