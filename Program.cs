using System.Text.RegularExpressions;

internal class Program
{
	public static void Main(string[] args)
	{
		Console.WriteLine("Welcome to the Pig Latin Translator!");
		bool active = true;
		while (active)
		{
			string input;
			bool valid = true;
			while (valid)
			{
				Console.WriteLine("Enter something to translate.");
				input = Console.ReadLine().ToLower();

				if (input != "")
				{
					valid = false;

					string[] words = input.Split();
					string endhalf = "";
					string firsthalf = "";
					foreach (string word in words)
					{
						Regex letter = new Regex("^[a-zA-Z]+$");
						if (letter.IsMatch(word) != true)
						{
							Console.Write(word + " ");
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
				}
				else
				{
					valid = true;
					Console.WriteLine("You didn't enter anything, try again.");
				}
			}
			Console.WriteLine("\n");
			active = AskToContinue();
		}
	}
	public static bool AskToContinue()
	{
		Console.WriteLine("wanna translate again? (y/n)");
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