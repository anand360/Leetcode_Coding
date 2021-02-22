const bestSum = (targetSum, numbers, memo = {}) => {
    if (targetSum in memo) return memo[targetSum];
    if (targetSum === 0) return [];
    if (targetSum < 0) return null;

    let shortestCombination = null;

    for (let num of numbers) {
        const remainder = targetSum - num;
        const remainderResult = bestSum(remainder, numbers, memo);
        if (remainderResult !== null) {
            const combination = [...remainderResult, num];
            // if combination is shorter than the current shortest, update it.
            if(shortestCombination === null || combination.length < shortestCombination.length){
                shortestCombination = combination;
            }
        }
    }

    memo[targetSum] = shortestCombination;
    return shortestCombination;
};

// m = targetsum
// n = numbers
// Memorize
// time: O(n*m^2) 
// space: O(m^2)

// console.log(bestSum(100, [1,2,3,25]));


const bestSumTable = (target, numbers) => {
    const table = Array(target+1).fill(null);
    table[0] = [];

    let best = [];
    for (let i = 0; i <= target; i++) {
        if(table[i] !== null){
            for (let num of numbers) {
                var cur = [...table[i], num];
                // if cur length is less than whats already there. replace
                if(!table[i+num] || table[i+num].length > cur.length){
                    table[i+num] = cur;
                }
            }
        }     
    }

    return table[target];
}

console.log(bestSumTable(7, [5,3,4,7]));

// time: O(m^2n)
// space: O(m^2)