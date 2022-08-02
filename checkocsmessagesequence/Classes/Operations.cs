using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using checkocsmessagesequence.Classes.Containers;
using Oracle.ManagedDataAccess.Client;

namespace checkocsmessagesequence.Classes
{
    public class Operations
    {
        /// <summary>
        /// Dummy work for the application
        /// </summary>
        /// <param name="options"><see cref="CommandLineOptions"/></param>
        public static void RunWork(CommandLineOptions options)
        {
            var result = Operations.SequenceCheck(options.Environment);
            if (result.Exception is null)
            {
                if (result.Okay)
                {
                    Console.WriteLine("Table is in synch with sequence!!!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Table is out of sync with sequence!!!");
                    Console.ResetColor();
                    Console.WriteLine($"Sequence: {result.CurrentSequence}");
                    Console.WriteLine($"Table: {result.TableSequence}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Issues reading from database");
                Console.ResetColor();
                Console.WriteLine(result.Exception.Message);
            }
        }

        /// <summary>
        /// Determine if OCS_MESSAGES is in sync with USER_SEQUENCES
        ///
        /// NOTE: Currently 1/3/2022 if -e or --env is optional which defaults to 'dev'
        /// 
        /// </summary>
        /// <param name="environment"></param>
        /// <returns></returns>
        public static SequenceResult SequenceCheck(ServerEnvironment environment)
        {
            SequenceResult result = new ();

            using var cn = new OracleConnection()
            {
                ConnectionString = ApplicationSettings.Instance.OracleDevelopmentConnectionString()
            };

            using var cmd = new OracleCommand
            {
                Connection = cn,
                CommandText = "SELECT LAST_NUMBER FROM USER_SEQUENCES  WHERE SEQUENCE_NAME = 'OCSMSG_SEQ'"
            };

            try
            {

                cn.Open();
                var lastIdentifier = (decimal)cmd.ExecuteScalar();
                result.CurrentSequence = lastIdentifier;
                cmd.CommandText = "SELECT * FROM (SELECT id FROM OCS_MESSAGES ORDER BY ID DESC) WHERE rownum = 1";
                var lastSequenceValue = (decimal)cmd.ExecuteScalar();

                result.TableSequence = lastSequenceValue;
                result.Okay = lastSequenceValue < lastIdentifier;

                return result;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
                return result;
            }

        }
    }
}
