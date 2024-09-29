using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class WeeklyAssignments : MonoBehaviour
{
    //Week 1:
    public void KnowHigher()
    {
        int valueA = Random.Range(1, 100); ;
        int valueB = Random.Range(1, 100); ;

        bool isHigher;
        string result;

        if (valueA > valueB)
        {
            isHigher = true;
            result = $"{valueA} is greater than {valueB}";
        }
        else
        {
            isHigher = false;
            result = $"{valueA} is NOT greater than {valueB}";
        }

        Debug.Log(isHigher + " " + result);
    }


    //Week 2:
    //generate a collection of random numbers
    //sort them in ascending order by value
    //Output your results to the console using Debug.Log.
    public List<int> GenerateRandomNumbers()
    {
        int listSize = 10;

        List<int> numbers = new List <int>();

        for (int i = 0; i < listSize; i++) { 
            int randomNumbers = Random.Range(0, 500);
            numbers.Add(randomNumbers);
        }

        return numbers;
    }
    
    public List <int> SortMyNumbers(List<int> numbers)
    {
        var currentIndex = 0;
        var nextIndex = currentIndex + 1;

        List<int > sortedNumbers = new List<int>(numbers);

        for(int i = 0; i < sortedNumbers.Count - 1; i++)
        {
            for(int j = i + 1; j < sortedNumbers.Count; j++)
            {
                // Compare current element with the next element
                if (sortedNumbers[j] < sortedNumbers[i])
                {
                    // Swap if the next element is smaller
                    int temp = sortedNumbers[i];
                    sortedNumbers[i] = sortedNumbers[j];
                    sortedNumbers[j] = temp;
                }  
            }
        }

        return sortedNumbers;
    }


    public void DisplaySortedNumbers()
    {
       //Generate Random Numbers:
       List <int> numbers = GenerateRandomNumbers();

       //Sort the Numbers:
       List<int> sortedNumbers = SortMyNumbers(numbers);

       //Output the unsorted and sorted number list to console
       Debug.Log("UNSORTED LIST: " + string.Join(", ", numbers));
       Debug.Log("Sorted Numbers: " + string.Join(", ", sortedNumbers));
    }


}
