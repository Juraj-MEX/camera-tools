using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z6NefFileFix
{
    interface IFileFixInfo
    {
        String OriginalCameraName { get; }
        String ReplacedCameraName { get; }
        Int32 Offset { get; }
        byte[] OriginalSequence { get; }
        byte[] ReplacedSequence { get; }
    }
}
