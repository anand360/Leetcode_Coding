const canConstruct = (target, wordBank, memo={}) => {
    if(target in memo) return memo[target];
    if(target === ''){
        return true;
    }

    for (let word of wordBank) {
        if(target.indexOf(word) === 0){
            const suffix = target.slice(word.length);
            if(canConstruct(suffix, wordBank, memo) === true){
                memo[target] = true;
                return memo[target];
            }
        }
    }

    memo[target] = false;
    return memo[target];
}

// console.log(canConstruct('abcdef', ["ab", "abc", "cd", "def", "abcd"]));

// memorize
// time: O(n*m^2)
// space: O(m^2)

// table
const canConstructTable=(target, wordBank) =>{
    const table = Array(target.length+1).fill(false);
    table[0] = true;

    for (let i = 0; i <= target.length; i++) {
        if(table[i] === true){
            for (let word of wordBank) {
                if(target.slice(i, i+word.length) == word){
                    table[i+word.length] = true;
                }
            }
        }        
    }

    return table[target.length];
}

console.log(canConstructTable('abcdef', ["ab", "abc", "cd", "def", "abcd"]));

// table
// time: O(n*m^2)
// space: O(m)