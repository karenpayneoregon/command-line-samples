using System;

namespace checkocsmessagesequence.Classes.Containers
{
    /// <summary>
    /// Choices for database environment
    /// </summary>
    /// <remarks>
    /// Parser is setup to accept upper or lower case e.g. Dev or dev
    /// </remarks>
    [Flags]
    public enum ServerEnvironment
    {
        dev,
        stage,
        prod
    }
}
