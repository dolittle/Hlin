using System;

namespace Hlin.Console
{
    public class ProgramOptions
    {
        public string DependencyFile { get; set; }
        public string TargetFile { get; set; }

        public bool IsValid
        {
            get
            {
                return 
                    !string.IsNullOrEmpty(DependencyFile) &&
                    !string.IsNullOrEmpty(TargetFile);
            }
        }
    }
}
