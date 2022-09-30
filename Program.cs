using System.Text.RegularExpressions;

internal class Program
{
	public static void Main(string[] args)
	{
		bool active = true;
		while (active)
		{
			string input = Console.ReadLine().ToLower();

			string[] words = input.Split();
			string endhalf = "";
			string firsthalf = "";

			foreach (string word in words)
			{
				Regex r = new Regex("^[a-zA-Z]+$");
				if (r.IsMatch(word) != true)
				{
					Console.Write(word+" ");
					continue;
				}
				for (int i = 0; word.Length > i; i++)
				{
					string current = (word[i].ToString());
					if (IsVowel(current))
					{
						int pos = word.Length - i;
						endhalf = word.Substring(i, pos);
						break;
					}
					else
					{
						firsthalf = word.Substring(0, (i + 1));
					}
				}
				char first = GetFirstLetter(word);
				string checker = first.ToString().ToLower();
				if (IsVowel(checker))
				{
					Console.Write(word + "way ");
				}
				else
				{
					Console.Write(endhalf + firsthalf + "ay ");
				}
			}
			Console.WriteLine("\n");
			active = AskToContinue();
		}
	}
	public static bool AskToContinue()
	{
		Console.WriteLine("wanna try another word? (y/n)");
		string input = Console.ReadLine().ToLower();
		if (input == "y")
		{
			return true;

		} else if (input == "n")
		{
			return false;
		} else
		{
			Console.WriteLine("try again (y/n)");
			return AskToContinue();
		}
	}
	public static char GetFirstLetter(string input)
	{	
		return input[0];
	}
	public static bool IsVowel(string checker)
	{
		if (checker == "a" || checker == "e" || checker == "i" || checker == "o" || checker == "u") {
			return true;
		} 
		else
		{
			return false;
		}
	}
}