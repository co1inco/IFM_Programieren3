namespace _4;

public static class StringExtension
{
    extension(string s)
    {

        public static string Repeat(int count, string text) => 
            string.Join("",  Enumerable.Repeat(text, count));
        
    }
}