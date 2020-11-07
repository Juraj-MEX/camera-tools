using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z6NefFileFix
{
    class Program
    {
        static void Main(string[] args)
        {
            // Enumerate files in current directory
            var nefFiles = Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*.nef", SearchOption.TopDirectoryOnly);

            IFileFixInfo ffi = new Z6FileFixInfo();

            foreach (var nefFile in nefFiles)
            {
                Console.WriteLine(nefFile);
                var headerFixer = new NefHeaderFixer(nefFile, ffi);
                headerFixer.fixHeader();
            }

        }
    }
}
