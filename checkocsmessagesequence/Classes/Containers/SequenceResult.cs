using System;

namespace checkocsmessagesequence.Classes.Containers
{
    public class SequenceResult
    {
        /// <summary>
        /// From USER_SEQUENCES
        /// </summary>
        public decimal CurrentSequence { get; set; }
        /// <summary>
        ///  From OCS_MESSAGES
        /// </summary>
        public decimal TableSequence { get; set; }
        /// <summary>
        /// Indicates sequence are synchronized 
        /// </summary>
        public bool Okay { get; set; }

        public Exception Exception { get; set; }

    }
}