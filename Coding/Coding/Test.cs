using System.Text;

public class TestMe{
    public static void Run(){
        var sb1 = new StringBuilder().Append("Hai");
        var sb2 = new StringBuilder().Append("Hello");
        int test = 6;

        Modify(sb1, sb2, test);
        var a = sb1;
        var b = sb2;
        var c = test; 
    }

    private static void Modify(StringBuilder sb1, StringBuilder sb2, int t){
        sb1= null;
        sb2.Append(" Test");
        t = 3;
    }
}