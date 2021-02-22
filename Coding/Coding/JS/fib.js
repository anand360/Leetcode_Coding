
// Memorize
const fib = (n, memo={}) => {
    if(n in memo) return  memo[n];
    if(n <= 2){
        return 1;
    }

    memo[n] = fib(n-1, memo) + fib(n -2, memo);
    return memo[n];
}

console.log(fib(50));

// tabulation
const fibTable = (n) => {
    const table = Array(n+1).fill(0);
    table[1] = 1;
    for (let i = 0; i <= n; i++) {
        table[i+1] += table[i];
        table[i+2] += table[i];      
    }

    return table[n];
}