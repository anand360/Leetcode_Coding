const countConstruct = (target, wordBank, memo={}) => {
    if(target in memo) return memo[target];
    if(target === ''){
        return 1;
    }

    let totalCount = 0;
    for (let word of wordBank) {
        if(target.indexOf(word) === 0){
            const suffix = target.slice(word.length);
            const count = countConstruct(suffix, wordBank, memo);
            totalCount += count;
        }
    }

    memo[target] = totalCount;
    return memo[target];
}

// console.log(countConstruct('abcdef', ["ab", "abc", "cd", "def", "abcd"]));

// memorize
// time: O(n*m^2)
// space: O(m^2)

// table
const countConstructTable=(target, wordBank) =>{
    const table = Array(target.length+1).fill(0);
    table[0] = 1;

    for (let i = 0; i <= target.length; i++) {
        if(table[i] !== 0){
            for (let word of wordBank) {
                if(target.slice(i, i+word.length) == word){
                    table[i+word.length] += table[i];
                }
            }
        }        
    }

    return table[target.length];
}

console.log(countConstruct('abcdef', ["ab", "abc", "cd", "def", "abcd"]));