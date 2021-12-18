// https://leetcode.com/problems/count-unique-characters-of-all-substrings-of-a-given-string/discuss/1505263/Single-pass-O(n)-time-and-O(1)-space-solution-with-detailed-explanation

let countDistinctSubString = function (input){
    let n = input.length;

    var ans = 0;
    var cur = 0;

    var last = Array(26).fill(-1);
    var prev = Array(26).fill(-1);

    for (let i = 0; i < n; i++) {
        let c = input[i];
        
        cur += (i - last[c.charCodeAt(0) - 'a'.charCodeAt(0)] - 1) - (last[c.charCodeAt(0) - 'a'.charCodeAt(0)] - prev[c.charCodeAt(0) - 'a'.charCodeAt(0)]) + 1;
        prev[c.charCodeAt(0) - 'a'.charCodeAt(0)] = last[c.charCodeAt(0) - 'a'.charCodeAt(0)];
        last[c.charCodeAt(0) - 'a'.charCodeAt(0)] = i;

        ans += cur;
    }

    return ans;
}

console.log(countDistinctSubString("test"));