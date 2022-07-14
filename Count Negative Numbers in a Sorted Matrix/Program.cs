using System;

namespace Count_Negative_Numbers_in_a_Sorted_Matrix
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
  }


  public class Solution
  {
    public int CountNegatives(int[][] grid)
    {
      int ROW = grid.Length;
      int COLUMN = grid[0].Length;
      int count = 0;
      int lastNegetive = COLUMN - 1;
      for (int i = 0; i < ROW; i++)
      {
        // if row starts with negetive then entire row will have only negetive nos as the row nos are sorted in Desc
        if (grid[i][0] < 0)
        {
          count += COLUMN;
          continue;
        }
        // If the last element in a row is positive then entire row elements are positive
        if (grid[i][COLUMN - 1] > 0)
        {
          // do nothing skip and move to the next row
          continue;
        }

        // Perform Binary Search in a row having both positive and negetive elements
        int l = 0; int r = lastNegetive;
        while (l <= r)
        {
          int mid = l + ((r - l) / 2);
          if (grid[i][mid] < 0)
          {
            r = mid - 1;
          }
          else
          {
            l = mid + 1;
          }
        }

        // we have found the negetive no if present
        count += COLUMN - l;
        // update the negetive no found index, lastNegetive would be the r for BS in the next row
        // why ? As the question mentioned the values are in column aslo in desc
        // so if you found a negetive no in a column the below all rows in that same column would also have negetive
        lastNegetive = l;
      }

      return count;
    }
  }
}
