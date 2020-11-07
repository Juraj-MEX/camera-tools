using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z6NefFileFix
{
    class NefHeaderFixer
    {
        readonly String          FileName;
        readonly IFileFixInfo    FileFixInfo;

        public NefHeaderFixer(string fileName, IFileFixInfo fileFixInfo)
        {
            this.FileName = fileName;
            this.FileFixInfo = fileFixInfo;

            if (FileFixInfo.OriginalSequence.Length != FileFixInfo.ReplacedSequence.Length)
            {
                throw new InvalidDataException("Length of original and replaced sequence does not match");
            }
        }

        public void fixHeader()
        {
            using (var mmf = MemoryMappedFile.CreateFromFile(FileName, System.IO.FileMode.Open))
            {
                int dataLength = FileFixInfo.OriginalSequence.Length;
                using (var accessor = mmf.CreateViewAccessor(FileFixInfo.Offset, dataLength))
                {
                    byte[] fileHeaderData = new byte[dataLength];

                    accessor.ReadArray(0, fileHeaderData, 0, dataLength);

                    if (fileHeaderData.SequenceEqual(FileFixInfo.OriginalSequence))
                    {
                        Console.WriteLine(String.Format("{0} tag found in file header. Replacing by {1} tag.", FileFixInfo.OriginalCameraName, FileFixInfo.ReplacedCameraName));
                        accessor.WriteArray(0, FileFixInfo.ReplacedSequence, 0, dataLength);
                    }
                    else
                    {
                        Console.WriteLine(String.Format("{0} tag not found in file header.", FileFixInfo.OriginalCameraName));
                    }
                }
            }
        }
    }
}
