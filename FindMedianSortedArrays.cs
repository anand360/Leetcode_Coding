// https://www.ideserve.co.in/learn/find-median-of-two-sorted-arrays
using System;

public class FindMedianSortedArrays
{
    public static double Run(int[] nums1, int[] nums2)
    {
        if (nums1 == null || nums1.Length == 0)
        {
            return getMedian(nums2, 0, nums2.Length - 1);
        }

        if (nums2 == null || nums2.Length == 0)
        {
            return getMedian(nums1, 0, nums1.Length - 1);
        }

        return GetSortMedian(nums1, nums2, 0, 0, nums1.Length - 1, nums2.Length - 1);
    }

    private static double GetSortMedian(int[] a, int[] b, int ai, int bi, int ae, int be)
    {
        if (Math.Abs(ai - ae) <= 1 && Math.Abs(bi - be) <= 1)
        {
            double re = 1.0 * (Math.Max(a[ai], b[bi]) + Math.Min(a[ae], b[be])) / 2;
            return re;
        }

        var m1 = getMedian(a, ai, ae);
        var m2 = getMedian(b, bi, be);

        if (m1 == m2)
        {
            return m1;
        }
        else if (m1 < m2)
        {
            if ((ae - ai) % 2 == 0)
            {
                ai = (ae + ai) / 2;
                be = (be + bi) / 2;
            }
            else
            {
                ai = (ae + ai) / 2;
                be = ((be + bi) / 2) + 1;
            }
        }
        else
        {
            if ((be - bi) % 2 == 0)
            {
                ae = (ae + ai) / 2;
                bi = (be + bi) / 2;
            }
            else
            {
                ae = ((ae + ai) / 2) + 1;
                bi = (be + bi) / 2;
            }
        }

        return GetSortMedian(a, b, ai, bi, ae, be);
    }

    private static double getMedian(int[] nums, int l, int r)
    {
        if ((r - l) % 2 == 0)
        {
            return 1.0 * nums[(r + l) / 2];
        }
        else
        {
            return 1.0 * (nums[(r + l) / 2] + nums[((r + l) / 2) + 1]) / 2;
        }
    }
}