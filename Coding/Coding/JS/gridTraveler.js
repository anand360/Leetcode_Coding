const gridTraveler = (m, n) => {
    const table = Array(m+1)
    .fill()
    .map(() => Array(n+1).fill(0));

    table[1][1] = 1;
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            const cur = table[i][j];
            if(j+1 <= n) table[i][j+1] += cur;
            if(i+1 <= m) table[i+1][j] += cur;         
        }      
    }

    return table[m][n];
}

// time: O(mn)
// space: O(mn)