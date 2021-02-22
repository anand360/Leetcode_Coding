// https://leetcode.com/problems/knight-dialer/
// Other sol: https://leetcode.com/problems/knight-dialer/discuss/189252/O(logN)
// T: O(n)
// S: O(1)

public class KnightDialer{
    public static int Run(int n){
        var prev = new long[]{1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
        long MOD = 1000000007;

        var validMoves = new int[][]{
            new int[]{4, 6},
            new int[]{6, 8},
            new int[]{7, 9},
            new int[]{4, 8},
            new int[]{3, 9, 0 },
            new int[]{},
            new int[]{1, 7, 0 },
            new int[]{2, 6},
            new int[]{1, 3},
            new int[]{2, 4}
        };

        for (int i = 0; i < n-1; i++)
        {
            var cur = new long[10];
            for (int j = 0; j < 10; j++)
            {
                foreach (var k in validMoves[j])
                {
                    cur[j] = (cur[j] + prev[k]) % MOD;
                }
            }

            prev = cur;
        }

        long ans = 0;
        for (int i = 0; i < prev.Length; i++)
        {
            ans = (ans + prev[i]) % MOD;
        }

        return (int)ans;
    }
}