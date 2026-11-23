using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LearningBasic.Labs.Lab03_Patterns;

public static class Exercises
{
    // 3.1 TWO POINTERS. Array urut naik. Adakah pasangan yang jumlahnya = target?
    //     Target: O(n) time, O(1) space. Tanpa nested loop.
    public static bool HasPairWithSum(int[] sorted, int target)
    {
        int left = 0;
        int right = sorted.Length - 1;
        int total = 0;
        while(left < right)
        {
            total = sorted[left] + sorted[right];
            if (total == target) return true;
            if (total < target) left++;
            if (total > target) right--;
        }
        return false;
    }

    // 3.2 SLIDING WINDOW (ukuran tetap). Jumlah terbesar dari k angka berturut-turut.
    //     k < 1 atau k > length -> ArgumentException.   [2,1,5,1,3,2], k=3 -> 9
    public static int MaxWindowSum(int[] nums, int k)
    {
        if (k > nums.Length) throw new ArgumentException("3.2 k bigger than array");
        int window = 0;
        for (int i = 0; i < k; i++) window += nums[i];
        int best = window;
        for(int i = k; i < nums.Length; i++)
        {
            window += nums[i] - nums[i-k];
            best = Math.Max(best, window);
        }
        return best;
    }

    // 3.3 PREFIX SUM. Jawab setiap query (From, To), inclusive, O(1) per query setelah satu kali O(n).
    public static int[] RangeSums(int[] nums, (int From, int To)[] queries)
    {
        int[] prefix = new int[nums.Length + 1];
        for (int i = 0; i < nums.Length; i++)
            prefix[i + 1] = prefix[i] + nums[i];
        
        foreach (var item in prefix)
        {
            Console.WriteLine(item);
        }

        int[] results = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            var (from, to) = queries[i];
            results[i] = prefix[to + 1] - prefix[from];
        }

        return results;
    }

    // 3.4 BINARY SEARCH. Index dari target, atau -1. Jangan pakai Array.BinarySearch.
    public static int BinarySearch(int[] sorted, int target)
    {
        int low = 0;
        int high = sorted.Length - 1;
        while (low <= high)
        {
            int mid = low + (low + high) / 2;
            if (sorted[mid] == target) return mid;
            if (sorted[mid] < target) low = mid + 1;
            else high = mid - 1;
        }
        return -1;
    }

    // 3.5 STACK. Elemen lebih besar berikutnya di sebelah kanan, atau -1.   [4, 5, 2, 25] -> [5, 25, 25, -1]
    public static int[] NextGreater(int[] nums)
    {
        throw new NotImplementedException();
    }

    // 3.6 BFS. Langkah tersedikit dari 'S' ke 'E' (atas/bawah/kiri/kanan). '#' = tembok. Tidak bisa -> -1.
    public static int ShortestPath(string[] grid)
    {
        throw new NotImplementedException();
    }
}