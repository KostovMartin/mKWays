using System;
using System.Threading;
using Mk.AJAX;
using MkAjax.Demo.Models;
using Newtonsoft.Json;

namespace MkAjax.Demo.webapi
{
    [AjaxClass]
    public class WebMethods : AjaxHandler
    {
        public WebMethods() : base(new MkJson()) {}

        [AjaxMethod]
        public static string AsyncPost()
        {
            return "Async Post Example.";
        }

        [AjaxMethod(RequestType = RequestType.Get)]
        public static string AsyncGet()
        {
            return "Async Get Example.";
        }

        [AjaxMethod]
        public static string AsyncPostWithParams(string firstName, string lastName)
        {
            return string.Format("Hello, {0} {1}!{2}I am Post.", firstName, lastName, Environment.NewLine);
        }

        [AjaxMethod(RequestType = RequestType.Get)]
        public static string AsyncGetWithParams(string firstName, string lastName)
        {
            return string.Format("Hello, {0} {1}!{2}I am Get.", firstName, lastName, Environment.NewLine);
        }

        [AjaxMethod(ExecutionType = ExecutionType.Blocking)]
        public static string Blocking()
        {
            const int timer = 1200;
            Thread.Sleep(timer);
            return string.Format("I blocked your UI, for ~{0} ms.{1}Look at button styles next time.", timer,
                Environment.NewLine);
        }

        [AjaxMethod]
        public static string GetObject()
        {
            return JsonConvert.SerializeObject(new MainObject
            {
                Id = 100,
                Name = "MyObject",
                Data = new OtherObject {Description = "Very long description."}
            });
        }

        [AjaxMethod]
        public static MainObject GetObjectDefaultSerialization()
        {
            return new MainObject
            {
                Id = 100,
                Name = "GetObjectDefaultSerialization",
                Data = new OtherObject {Description = "Very long description."}
            };
        }

        [AjaxMethod]
        public static MyTestModel SendModelAsParameter(MyTestModel model)
        {
            // use the model here
            return model;
        }
    }
}