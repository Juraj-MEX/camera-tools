using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Z6NefFileFix
{
    class Z6FileFixInfo : IFileFixInfo
    {
        private readonly int sequenceOffset = 0x168;

        private readonly string originalCameraName = "Nikon Z6 II";
        private readonly string replacedCameraName = "Nikon Z6";

        private readonly byte[] originalSequence = new byte[] {
            0x4E, 0x49, 0x4B, 0x4F, 0x4E, 0x20, 0x43, 0x4F, 0x52, 0x50, 0x4F, 0x52, 0x41, 0x54, 0x49, 0x4F,
            0x4E, 0x00, 0x00, 0x00, 0x4E, 0x49, 0x4B, 0x4F, 0x4E, 0x20, 0x5A, 0x20, 0x36, 0x5F, 0x32, 0x00
        };

        private readonly byte[] replacedSequence = new byte[] {
            0x4E, 0x49, 0x4B, 0x4F, 0x4E, 0x20, 0x43, 0x4F, 0x52, 0x50, 0x4F, 0x52, 0x41, 0x54, 0x49, 0x4F,
            0x4E, 0x00, 0x00, 0x00, 0x4E, 0x49, 0x4B, 0x4F, 0x4E, 0x20, 0x5A, 0x20, 0x36, 0x00, 0x00, 0x00
        };

        int IFileFixInfo.Offset => sequenceOffset;

        string IFileFixInfo.OriginalCameraName => originalCameraName;

        string IFileFixInfo.ReplacedCameraName => replacedCameraName;

        byte[] IFileFixInfo.OriginalSequence => originalSequence;

        byte[] IFileFixInfo.ReplacedSequence => replacedSequence;
    }
}
