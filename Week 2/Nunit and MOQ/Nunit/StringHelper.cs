namespace Nunit
{
    public class StringHelper
    {
        public string Reverse(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        public bool IsPalindrome(string input)
        {
            if (string.IsNullOrEmpty(input))
                return true;
            
            string cleaned = input.ToLower().Replace(" ", "");
            return cleaned == Reverse(cleaned).ToLower();
        }

        public int CountWords(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;
            
            return input.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
