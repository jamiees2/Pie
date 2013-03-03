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

        public FKModel Model { get; set; }

        public char VerticalChar { get; set; }

        public char HorizontalChar { get; set; }

        private IEnumerable<FKActionMetadata> Actions
        {
            get
            {
                return (IEnumerable<FKActionMetadata>)Enumerable.OrderBy<FKActionMetadata, string>(Enumerable.Select(Enumerable.Select(Enumerable.Where<MethodInfo>((IEnumerable<MethodInfo>)this.GetType().GetMethods(), (Func<MethodInfo, bool>)(a =>
                {
                    if (a.IsPublic && Attribute.IsDefined((MemberInfo)a, typeof(FKActionAttribute)))
                        return !Enumerable.Any<ParameterInfo>((IEnumerable<ParameterInfo>)a.GetParameters());
                    else
                        return false;
                })), a => new
                {
                    a = a,
                    attr = Attribute.GetCustomAttribute((MemberInfo)a, typeof(FKActionAttribute)) as FKActionAttribute
                }), param0 => new FKActionMetadata()
                {
                    Method = param0.a,
                    Name = param0.attr.Name,
                    Description = param0.attr.Description + (!param0.attr.Finished ? " (unfinished)" : "")
                }), (Func<FKActionMetadata, string>)(a => a.Name), (IComparer<string>)new AlphaNumberComparer(AlphaNumberSettings.Leading));
            }
        }

        public FKController(FKModel model, string title = null, char verticalChar = '-', char horizontalChar = '|', string[] args = null)
        {
            this.Model = model;
            this.Title = title;
            this.VerticalChar = verticalChar;
            this.HorizontalChar = horizontalChar;
            try
            {
                if (args == null || !Enumerable.Any<string>((IEnumerable<string>)args))
                    return;
                bool flag = Enumerable.Any<string>(Enumerable.Skip<string>((IEnumerable<string>)args, 1)) && StringExtensions.StartsWithIgnoreCase(args[1], "T");
                while (true)
                {
                    do
                    {
                        this.ExecuteAction(Enumerable.First<string>((IEnumerable<string>)args), true, true);
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
            int num = Enumerable.Max(Enumerable.Select<string, int>((IEnumerable<string>)strArray, (Func<string, int>)(l => l.Length)));
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
            FKActionMetadata fkActionMetadata = Enumerable.FirstOrDefault<FKActionMetadata>(Enumerable.Select(Enumerable.OrderBy(Enumerable.Where(Enumerable.Select(this.Actions, a => new
            {
                a = a,
                distance = StringExtensions.DistanceTo(a.Name, actionName, false)
            }), param0 => param0.distance <= 3), param0 => param0.distance), param0 => param0.a));
            if (fkActionMetadata == null || actionName.Trim() == "")
                fkActionMetadata = Enumerable.FirstOrDefault<FKActionMetadata>(this.Actions, (Func<FKActionMetadata, bool>)(a => a.Name == "Exit"));
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
            foreach (FKActionMetadata fkActionMetadata in Enumerable.Where<FKActionMetadata>(this.Actions, (Func<FKActionMetadata, bool>)(a => !a.Name.BelongsTo<string>("All", "Exit"))))
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
            this.SimpleView(space, Enumerable.ToArray<object>(objs));
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
