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
    public abstract class FKController
    {
        public string Title { get; set; }

        //public FKModel Model { get; set; }

        public char VerticalChar { get; set; }

        public char HorizontalChar { get; set; }

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

        public FKController(string title = null, char verticalChar = '-', char horizontalChar = '|', string[] args = null)
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

        public void ListActions()
        {
            if (this.Title != null)
                this.WriteHeader(this.Title);
            foreach (object obj in this.Actions)
                Console.WriteLine(obj.ToString());
            Console.WriteLine();
        }

        private void WriteHeader(string header)
        {
            string[] strArray = header.SplitLines();
            int num = strArray.Select(x => x.Length).Max();
            string str1 = new string(this.VerticalChar, num + 4);
            Console.WriteLine(str1);
            foreach (string str2 in strArray)
            {
                Console.Write(this.HorizontalChar);
                Console.Write(' ');
                Console.Write(str2);
                Console.Write(new string(' ', num - str2.Length + 1));
                Console.WriteLine(this.HorizontalChar);
            }
            Console.WriteLine(str1);
            Console.WriteLine();
        }

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
            Console.ReadLine();
        }

        [FKAction("All", Description = "Run all the actions.")]
        public void All()
        {
            foreach (FKActionMetadata fkActionMetadata in this.Actions.Where(x => !x.Name.BelongsTo<string>("All","Exit")))
                this.ExecuteAction(fkActionMetadata.Name, true, true);
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                this.ListActions();
                Console.Write("Run: ");
                this.ExecuteAction(Console.ReadLine(), true, true);
            }
        }

        [FKAction("Exit", Description = "Exit the program.")]
        public void Exit()
        {
            Environment.Exit(0);
        }

        public virtual void PreActionExecute()
        {
        }

        public virtual void PostActionExecute()
        {
        }

        public void SimpleView(IEnumerable<object> objs, bool space = true)
        {
            this.SimpleView(space, objs.ToArray());
        }

        public void SimpleView(bool space = true, params object[] objs)
        {
            if (space)
                Console.WriteLine();
            foreach (object obj in objs)
                Console.WriteLine(obj);
        }

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

        public void SimpleView(string s, bool space = true)
        {
            if (space)
                Console.WriteLine();
            Console.WriteLine(s);
        }

        public void BoolView(bool condition, string trueString, string falseString, bool space = true)
        {
            if (space)
                Console.WriteLine();
            Console.WriteLine(condition ? trueString : falseString);
        }

        public void BoolView(bool condition, string start, string not, string end, bool space = true)
        {
            if (space)
                Console.WriteLine();
            Console.Write(start);
            Console.Write(" ");
            if (!condition)
            {
                Console.Write(not);
                Console.Write(" ");
            }
            Console.WriteLine(end);
        }
    }
}
