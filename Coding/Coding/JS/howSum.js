const howSum = (targetSum, numbers, memo = {}) => {
    if(targetSum in memo) return memo[targetSum];
    if(targetSum === 0) return [];
    if(targetSum < 0) return null;

    for (const num of numbers) {
        const remainder = targetSum - num;
        const remainderResult = howSum(remainder, numbers, memo);
        if(remainderResult !== null){
            memo[targetSum] = [...remainderResult, num];
            return memo[targetSum];
        }
    }

    memo[targetSum] = null;
    return null;
};

// m = targetsum
// n = numbers
// Memorize
// time: O(n*m^2)
// space: O(m^2)

// tablulize
const howSumTable = (target, numbers) => {
    const table = Array(target+1).fill(null);
    table[0] = [];

    for (let i = 0; i <= target; i++) {
        if(table[i] !== null){
            for (let num of numbers) {
                table[i+num] = [...table[i], num];
            }
        }     
    }

    return table[target];
}

console.log(howSumTable(7, [5,3,4]));

// time: O(m^2n)
// space: O(m^2)