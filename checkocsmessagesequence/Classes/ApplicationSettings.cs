using System;

namespace checkocsmessagesequence.Classes
{
    public sealed class ApplicationSettings
    {
        private static readonly Lazy<ApplicationSettings> Lazy = new(() => new ApplicationSettings());

        public static ApplicationSettings Instance => Lazy.Value;



        /// <summary>
        /// Provides a complete connection to Oracle database server for development environment
        /// </summary>
        public string OracleDevelopmentConnectionString(string userId = "ocs", string password = "ocsdog") =>
            "Data Source=aix-aixtest.emp.state.or.us:1521/TEST.EMP.STATE.OR.US;" +
            "Persist Security Info=True;Enlist=false;Pooling=true;Statement Cache Size=10;" +
            $"User ID={userId};Password={password};";

        /// <summary>
        /// Provides a complete connection excluding password to Oracle database server for development environment
        /// </summary>
        public string OracleDevelopmentConnectionStringTest(string userId = "ocs", string password = "ocsdog") =>
            "Data Source=aix-aixtest.emp.state.or.us:1521/TEST.EMP.STATE.OR.US;" +
            "Persist Security Info=True;Enlist=false;Pooling=true;Statement Cache Size=10;" +
            $"User ID={userId};Password={password};";
    }
}
