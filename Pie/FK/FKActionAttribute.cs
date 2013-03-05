using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pie.FK
{
    /// <summary>
    /// Used to designate an action method
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class FKActionAttribute : Attribute
    {
        /// <summary>
        /// The name of the method
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description for the method
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Wether the method has been completed
        /// </summary>
        public bool Finished { get; set; }

        /// <summary>
        /// Creates a new instance and sets the name
        /// </summary>
        /// <param name="name"></param>
        public FKActionAttribute(string name)
        {
            this.Name = name;
            this.Finished = true;
        }

        /// <summary>
        /// Creates a new instance with a name and description
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public FKActionAttribute(string name, string description)
        {
            this.Name = name;
            this.Description = description;
            this.Finished = true;
        }

        /// <summary>
        /// Creates a new instance with a name and description, and wether it has been finished
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="finished"></param>
        public FKActionAttribute(string name, string description, bool finished)
        {
            this.Name = name;
            this.Description = description;
            this.Finished = finished;
        }
    }
}
