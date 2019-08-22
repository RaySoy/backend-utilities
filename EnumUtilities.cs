using System;
using System.Collections.Generic;

namespace Noleggio.DAL.Utilities
{
    public class EnumUtilities<TValue>
    {
        //READ ME
        //
        //BUG
        //ENUM WITH CHAR VALUED ITEMS ARE NOT SUPPORTED

        /// <summary>
        /// 
        /// </summary>
        public class ReturnedItem
        {
            public string label { get; set; }
            public TValue id { get; set; }
        }
        /// <summary>
        /// The method's transform the enum to a list.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public List<ReturnedItem> ToList<TEnum>()
        {
            try
            {
                //The list to return
                List<ReturnedItem> response = new List<ReturnedItem>();
				
                //Get the type of the enum
                Type type = typeof(TEnum);
				
                //Get the enum values
                Array enumValues = Enum.GetValues(type);
				
                //Loop the enum values
                foreach (TValue i in enumValues)
                    response.Add(new ReturnedItem() { label = Enum.GetName(type, i), id = i });

                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// The method's transform the enum into a dictionary.
        /// </summary>
        /// <typeparam name="TEnum">The enum on which the method is going to work on.</typeparam>
        /// <returns>A dictionary obtained from TEnum.</returns>
        public Dictionary<string, TValue> ToDictionary<TEnum>()
        {
            try
            {
                //Get the type of the enum
                Type type = typeof(TEnum);
				
                //Get the enum values
                Array enumValues = Enum.GetValues(type);
				
                //
                Dictionary<string, TValue> response = new Dictionary<string, TValue>();
				
                //Loop
                foreach (TValue i in enumValues)
                    response.Add(Enum.GetName(type, i), i);
					
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Convert the list values to a list of enum.
        /// </summary>
        /// <typeparam name="TEnum">The enum on which the method is going to work on.</typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public List<TEnum> ToEnum<TEnum>(List<TValue> values)
        {
            try
            {
                List<TEnum> enums = new List<TEnum>();

                foreach (TValue value in values)
                    enums.Add((TEnum)Enum.Parse(typeof(TEnum), value.ToString()));

                return enums;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
