﻿HistorianHysteria historianHysteria = new HistorianHysteria();
string filePath = "Input.txt";
var (firstRow, SecondRow) = historianHysteria.ParseAndSortFile(filePath);
int sumOfDifferences = historianHysteria.CalculateSumOfDifferences(firstRow, SecondRow);
Console.WriteLine(sumOfDifferences.ToString());