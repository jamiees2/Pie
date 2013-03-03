using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pie;
using Pie.Comparers;
using Pie.Strings;
using System.Reflection;

namespace Pie.FK
{
    /// <summary>
    /// A controller for projects
    /// </summary>
    public abstract class FKController
    {
        /// <summary>
        /// The title of the project
        /// </summary>
        public string Title { get; set; }

        //public FKModel Model { get; set; }

        /// <summary>
        /// The character to use for vertical lines
        /// </summary>
        public char VerticalChar { get; set; }

        /// <summary>
        /// The character to use for horizontal lines
        /// </summary>
        public char HorizontalChar { get; set; }

        /// <summary>
        /// The actions for the controller
        /// </summary>
        private IEnumerable<FKActionMetadata> Actions
        {
            get
            {
                return 
                    this.GetType().GetMethods().Where(a =>
                    {
                        if (a.IsPublic && Attribute.IsDefined((MemberInfo)a, typeof(FKActionAttribute)))
                            return !a.GetParameters().Any();
                        else
                            return false;
                    }).Select(a => new
                    {
                        Method = a,
                        Attribute = Attribute.GetCustomAttribute((MemberInfo)a, typeof(FKActionAttribute)) as FKActionAttribute
                    }).Select(a => new FKActionMetadata()
                    {
                        Method = a.Method,
                        Name = a.Attribute.Name,
                        Description = a.Attribute.Description + (!a.Attribute.Finished ? " (unfinished)" : "")
                    }).OrderBy(a => a.Name, new AlphaNumberComparer(AlphaNumberSettings.Leading));
            }
        }

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="title">The title of the project</param>
        /// <param name="args">The args passed to the program</param>
        /// <param name="verticalChar">The character to use for vertical spaces</param>
        /// <param name="horizontalChar">The character to use for horizontal spaces</param>
        public FKController(string title = null, string[] args = null, char verticalChar = '-', char horizontalChar = '|')
        {
            this.Title = title;
            this.VerticalChar = verticalChar;
            this.HorizontalChar = horizontalChar;
            try
            {
                if (args == null || !args.Any())
                    return;
                bool flag = args.Skip(1).Any() && args[1].StartsWithIgnoreCase("T");
                while (true)
                {
                    do
                    {
                        this.ExecuteAction(args.First(), true, true);
                    }
                    while (flag);
                    this.Exit();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Prints all the actions to the console
        /// </summary>
        public void ListActions()
        {
            if (this.Title != null)
                this.WriteHeader(this.Title);
            foreach (object obj in this.Actions)
                PieConsole.WriteLine(obj.ToString());
            PieConsole.WriteLine();
        }

        /// <summary>
        /// Writes the header to the console
        /// </summary>
        /// <param name="header">The header</param>
        private void WriteHeader(string header)
        {
            string[] strArray = header.SplitLines();
            int num = strArray.Select(x => x.Length).Max();
            string str1 = new string(this.VerticalChar, num + 4);
            Console.WriteLine(str1);
            foreach (string str2 in strArray)
            {
                PieConsole.Write(this.HorizontalChar)
                    .Write(' ')
                    .Write(str2)
                    .Write(new string(' ', num - str2.Length + 1))
                    .WriteLine(this.HorizontalChar);
            }
            PieConsole.WriteLine(str1).WriteLine();
        }

        /// <summary>
        /// Executes the action by name
        /// </summary>
        /// <param name="actionName">The name of the action</param>
        /// <param name="pause">Wether to wait after executing the action</param>
        /// <param name="header">Wether to show the header</param>
        public void ExecuteAction(string actionName, bool pause = false, bool header = false)
        {
            FKActionMetadata fkActionMetadata = this.Actions.Select(a => new { A = a, Distance = a.Name.DistanceTo(actionName, false) })
                .Where(x => x.Distance <= 3)
                .OrderBy(x => x.Distance)
                .Select(x => x.A).FirstOrDefault<FKActionMetadata>();

            if (fkActionMetadata == null || actionName.Trim() == "")
                fkActionMetadata = this.Actions.FirstOrDefault(a => a.Name == "Exit");
            if (fkActionMetadata == null)
                return;
            this.PreActionExecute();
            if (header)
                this.WriteHeader(fkActionMetadata.Name + (fkActionMetadata.Description != null ? "\n" + fkActionMetadata.Description : ""));
            fkActionMetadata.Method.Invoke((object)this, new object[0]);
            this.PostActionExecute();
            if (!pause)
                return;
            PieConsole.ReadLine();
        }

        /// <summary>
        /// An action that simply runs all the actions
        /// </summary>
        [FKAction("All", Description = "Run all the actions.")]
        public void All()
        {
            foreach (FKActionMetadata fkActionMetadata in this.Actions.Where(x => !x.Name.BelongsTo<string>("All","Exit")))
                this.ExecuteAction(fkActionMetadata.Name, true, true);
        }

        /// <summary>
        /// Runs the Controller, shows the choice box and executes actions
        /// </summary>
        public void Run()
        {
            while (true)
            {
                PieConsole.Clear();
                this.ListActions();
                this.ExecuteAction(PieConsole.ReadLineQ("Run"), true, true);
            }
        }

        /// <summary>
        /// An action that simply exits the program
        /// </summary>
        [FKAction("Exit", Description = "Exit the program.")]
        public void Exit()
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Runs before each action
        /// </summary>
        public virtual void PreActionExecute()
        {
        }

        /// <summary>
        /// Runs after each action
        /// </summary>
        public virtual void PostActionExecute()
        {
        }

        #region Views
        /// <summary>
        /// A simple view for printing out the specified objects
        /// </summary>
        /// <param name="objs">The objects</param>
        /// <param name="space">Wether to prepend with a newline</param>
        public void SimpleView(IEnumerable<object> objs, bool space = true)
        {
            this.SimpleView(space, objs.ToArray());
        }

        /// <summary>
        /// A simple view that prints out all it's parameters
        /// </summary>
        /// <param name="space">Wether to prepend with a newline</param>
        /// <param name="objs">The objects</param>
        public void SimpleView(bool space = true, params object[] objs)
        {
            if (space)
                Console.WriteLine();
            foreach (object obj in objs)
                Console.WriteLine(obj);
        }

        /// <summary>
        /// A simple view that prints out a dictionary
        /// </summary>
        /// <param name="objs">The dictionary to show</param>
        /// <param name="between">What to print between the key and the value</param>
        /// <param name="space">Wether to prepend the output with a newline</param>
        public void SimpleView(Dictionary<string, object> objs, string between = ": ", bool space = true)
        {
            if (space)
                Console.WriteLine();
            foreach (KeyValuePair<string, object> keyValuePair in objs)
            {
                Console.Write(keyValuePair.Key);
                Console.Write(between);
                Console.WriteLine(keyValuePair.Value);
            }
        }

        /// <summary>
        /// A simple view that prints out a string
        /// </summary>
        /// <param name="s">The string to print out</param>
        /// <param name="space">Wether to prepend the output with a newline</param>
        public void SimpleView(string s, bool space = true)
        {
            if (space)
                Console.WriteLine();
            Console.WriteLine(s);
        }

        /// <summary>
        /// A simple view that prints out a string based on the value of a boolean
        /// </summary>
        /// <param name="condition">The conditional</param>
        /// <param name="trueString">What to print out if the condition is true</param>
        /// <param name="falseString">What to print out if the condition is false</param>
        /// <param name="space">Wehter to prepend the output with a newline</param>
        public void BoolView(bool condition, string trueString, string falseString, bool space = true)
        {
            if (space)
                Console.WriteLine();
            Console.WriteLine(condition ? trueString : falseString);
        }

        /// <summary>
        /// A simple view that prints out a string if the boolean is false
        /// </summary>
        /// <param name="condition">The conditional</param>
        /// <param name="start">The output to prepend</param>
        /// <param name="not"></param>
        /// <param name="end"></param>
        /// <param name="space"></param>
        public void BoolView(bool condition, string start, string not, string end, bool space = true)
        {
            if (space)
                PieConsole.WriteLine();
            PieConsole.Write(start).Write(" ");
            if (!condition)
            {
                PieConsole.Write(not).Write(" ");
            }
            PieConsole.WriteLine(end);
        }

        #endregion
    }
}
