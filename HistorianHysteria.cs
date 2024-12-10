public class HistorianHysteria
{
    public HistorianHysteria()
    {
    }

    public (List<int> firstRow, List<int> secondRow) ParseAndSortFile(string filename)
    {
        List<int> firstNumbers = new List<int>();
        List<int> secondNumbers = new List<int>();

        string directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        string fileName = "Input.txt";
        string filePath = Path.Combine(directory, fileName);

        try
        {
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var numbers = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbers.Length >= 2)
                {
                    firstNumbers.Add(int.Parse(numbers[0]));
                    secondNumbers.Add(int.Parse(numbers[1]));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        firstNumbers.Sort();
        secondNumbers.Sort();

        return (firstNumbers, secondNumbers);
    }

    // Part 1
    public int CalculateSumOfDifferences(List<int> firstNumbers, List<int> secondNumbers)
    {
        int totalDifference = 0;

        for (int i = 0; i < Math.Min(firstNumbers.Count, secondNumbers.Count); i++)
        {
            totalDifference += Math.Abs(firstNumbers[i] - secondNumbers[i]);
        }

        return totalDifference;
    }

    // Part 2
    public int CalculateSimilarityScore(List<int> firstNumbers, List<int> secondNumbers)
    {
        int similarityScore = 0;

        foreach (var number in firstNumbers)
        {
            int rightListCount = secondNumbers.FindAll(x => x == number).Count;
            similarityScore += number * rightListCount;
        }

        return similarityScore;
    }
}
