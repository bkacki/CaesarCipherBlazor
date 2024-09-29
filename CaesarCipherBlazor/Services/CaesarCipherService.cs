namespace CaesarCipherBlazor.Services
{
    public interface ICaesarCipherService
    {
        string Encode(string message, int shift);
        string Decode(string message, int shift);
    }

    public class CaesarCipherService : ICaesarCipherService
    {
        private const int lowerCaseConst = 97;
        private const int capitalLetterConst = 65;

        public string Encode(string message, int shift)
        {
            shift = shift > 26 ? shift % 26 : shift;
            char[] charArray = message.ToCharArray();
            char[] encodedCharArray = new char[charArray.Length];

            for (int i = 0; i < charArray.Length; i++)
            {
                if ((byte)charArray[i] >= 97 && (byte)charArray[i] <= 122)
                    encodedCharArray[i] = (char)(lowerCaseConst + ((byte)charArray[i] - lowerCaseConst + shift + 26) % 26);
                else if ((byte)charArray[i] >= 65 && (byte)charArray[i] <= 90)
                    encodedCharArray[i] = (char)(capitalLetterConst + ((byte)charArray[i] - capitalLetterConst + shift + 26) % 26);
                else
                    encodedCharArray[i] = charArray[i];
            }

            return new string(encodedCharArray);
        }

        public string Decode(string message, int shift)
        {
            shift = shift > 26 ? shift % 26 : shift;
            char[] charArray = message.ToCharArray();
            char[] decodedCharArray = new char[charArray.Length];

            for (int i = 0; i < charArray.Length; i++)
            {
                if (IsLowerCaseLetter(charArray[i]))
                    decodedCharArray[i] = (char)(lowerCaseConst + ((byte)charArray[i] - lowerCaseConst - shift + 26) % 26);
                else if (IsCapitalLetter(charArray[i]))
                    decodedCharArray[i] = (char)(capitalLetterConst + ((byte)charArray[i] - capitalLetterConst - shift + 26) % 26);
                else
                    decodedCharArray[i] = charArray[i];
            }

            return new string(decodedCharArray);
        }

        private bool IsCapitalLetter(char c) => (c >= 'A' && c <= 'Z');
        private bool IsLowerCaseLetter(char c) => (c >= 'a' && c <= 'z');
    }
}
