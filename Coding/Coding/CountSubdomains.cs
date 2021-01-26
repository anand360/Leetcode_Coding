// Coding challenge
// ================



// Domain log data



// Input (example):
// ----------------



// "100 microsoft.com",
// "30 test.microsoft.com",
// "50 msftapps.net",
// "18 msftapps.com",
// "100 foo.bar.test.bit.apple.com",
// "1 z.apple.com"



// Expected Output (example):
// --------------------------



// 249 com
// 30 test.microsoft.com
// 18 msftapps.com
// 130 microsoft.com
// 101 apple.com
// 1 z.apple.com
// 100 bit.apple.com
// 100 test.bit.apple.com
// 100 bar.test.bit.apple.com
// 100 foo.bar.test.bit.apple.com
// 50 net
// 50 msftapps.net



// Each domain name must appear exactly once
using System.Collections.Generic;
using System.IO;

public class CountSubdomains
{
    // public void PrintDomains(string path)
    // {
    //     var domainMap = new Dictionary<int, string>();

    //     // file io to read the file path stream
    //     using (var stream = new Stream(path))
    //     {
    //         var line = stream.nextline()
    //         while (line)
    //         {
    //             var domnainData = line.split(" ");
    //             var count = Convert.toint32(domainData[0]);
    //             var domainname = domainData[1];

    //             var splitDomainList = domainname.split(".");

    //             var subdomain = string.empty;
    //             for (int i = splitDomainList.length - 1; i > splitDomainList.length; i--)    /// microsoft.com /// com
    //             {
    //                 subdomain = splitDomainList[i] + "." + subdomain.trim(".");
    //                 if (domainMap.containkey(subdomain.trim(".")))
    //                 {
    //                     domainmap[subdomain.trim(".")] = domainmap[subdomain.trim(".")] + count;
    //                 }
    //                 else
    //                 {
    //                     domainmap(domainname.trim("."), count);
    //                 }
    //             }
    //         }
    //     }

    //     foreach (var item in domainmap)
    //     {
    //         System.Console.WriteLine($"{item.val} {item.key}");
    //     }
    // }
}
