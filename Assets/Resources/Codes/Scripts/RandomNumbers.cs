using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumbers : MonoBehaviour
{
    public int min = -20;
    public int max = 20;

    private List<int> numbers = new List<int>();

    public void GenerateNums(int min, int max)
    {
        numbers.Clear();

        for (int i = 0; i < 10; i++)
        {
            numbers.Add(Random.Range(min, max));
        }   
    }

    public List<int> GetNumbers()
    {
        return numbers;
    }

}
