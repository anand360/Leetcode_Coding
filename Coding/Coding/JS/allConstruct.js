const allConstruct = (target, wordBank, memo={}) => {
    if(target in memo) return memo[target];
    if(target === ''){
        return [[]];
    }

    let result = [];
    for (let word of wordBank) {
        if(target.indexOf(word) === 0){
            const suffix = target.slice(word.length);
            const suffixWays = allConstruct(suffix, wordBank, memo);

            const targetWays = suffixWays.map(way => [word, ...way]);
            result.push(...targetWays);
        }
    }

    memo[target] = result;
    return result;
}

// console.log(allConstruct('abcdef', ["ab", "abc", "cd", "def", "abcd"]));

// memorize
// time: O(n^m)
// space: O(m)

// table
const allConstructTable=(target, wordBank) =>{
    const table = Array(target.length+1)
    .fill()
    .map(() => []);

    table[0] = [[]];

    for (let i = 0; i <= target.length; i++) {
        for (let word of wordBank) {
            if(target.slice(i, i+word.length) === word){
                const newCombo = table[i].map(subArray =>[...subArray, word]);
                table[i+word.length].push(...newCombo);
            }
        }       
    }

    return table[target.length];
}

console.log(allConstructTable('abcdef', ["ab", "abc", "cd", "def", "abcd", "abcdef"]));