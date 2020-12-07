using System.Text;

public class EncryptedWords
{
    public static string Run(string s){
        if(string.IsNullOrWhiteSpace(s)){
            return s;
        }

        var a =  GetEncrypt(s, 0, s.Length-1);
        System.Console.WriteLine(a);
        return a;
    }

    private static string GetEncrypt(string s, int left, int right){
        if(right - left <= 1){
            var a =  s.Substring(left, right - left+1);
            return a;
        }

        int mid = (right + left) / 2;
        mid = mid % 2 == 0 ? mid-1 : mid;

        var st = new StringBuilder();
        st.Append(s[mid]);
        st.Append(GetEncrypt(s, left, mid -1));

        st.Append(GetEncrypt(s, mid+1, right));

        return st.ToString();
    }
}