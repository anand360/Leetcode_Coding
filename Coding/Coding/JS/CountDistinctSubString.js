let countDistinctSubString = function (input){
    let n = input.length;

    var ans = 0;
    var cnt = Array(26).fill(0);

    var i = 0, j = 0;

    while (i < n){
        if(j < n && (cnt[input[j].charCodeAt(0) - 'a'.charCodeAt(0)] == 0)){
            cnt[input[j].charCodeAt(0) - 'a'.charCodeAt(0)]++;

            ans += (j - i +1);
            j++;
        }
        else{
            cnt[input[i].charCodeAt(0) - 'a'.charCodeAt(0)]--;
            i++;
        }
    }

    return ans;
}

console.log(countDistinctSubString("test"));