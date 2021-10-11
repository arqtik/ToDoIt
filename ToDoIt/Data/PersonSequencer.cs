using System.Threading;
using System.Xml;

namespace ToDoIt.Data
{
    public class PersonSequencer
    {
        private static int personid;

        /// <summary>
        /// Get the id for the next person
        /// </summary>
        /// <returns>ID for the next person</returns>
        public static int nextPersonId()
        {
            personid++;
            return personid;
        }

        /// <summary>
        /// Reset PersonID counter to 0
        /// </summary>
        public static void reset()
        {
            personid = 0;
        }
    }
}