using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcBank
{
    public class CommonFunctions
    {
        /// <summary>
        ///  Make sure correct plural of word is created based on the number passed in:
        ///  If number passed in is 1 just return the word otherwise add an 's' at the end
        /// </summary>
        /// <param name="number"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static String pluralFormatter(int number, String word)
        {
            return number + " " + (number == 1 ? word : word + "s");
        }

        /// <summary>
        /// Gets the current datetime
        /// </summary>
        /// <returns></returns>
        public static DateTime now()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// Returns the currency value in dollars for the input amount
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static String toDollars(double d)
        {
            return String.Format("${0:N2}", Math.Abs(d));
        }

    }
}
