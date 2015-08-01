using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mk.AJAX;
using Mk.AJAX.Methods;

namespace Mk.Ajax.Tests
{
    [TestClass]
    public class ParametersSerializationTests
    {
        private IMethodCaller _methodCaller;

        [TestInitialize]
        public void Setup()
        {
            this._methodCaller = new MethodCaller(null, new MkJson());
        }

        [TestMethod]
        public void Parameter_BoolIsPassed_ShouldDeserializeToBool()

        {
            this._methodCaller.Call(GetWebMethod(), new NameValueCollection
            {
                {"p1", "true"}
            });
        }

        [AjaxMethod]
        public static void Parameter_BoolIsPassed_ShouldDeserializeToBool_WebMethod(bool p1)
        {
            Assert.AreEqual(true, p1);
        }

        [TestMethod]
        public void Parameter_BoolArrayIsPassed_ShouldDeserializeToBoolArray()
        {
            this._methodCaller.Call(GetWebMethod(), new NameValueCollection
            {
                {"p1", "[true, false, true]"}
            });
        }

        [AjaxMethod]
        public static void Parameter_BoolArrayIsPassed_ShouldDeserializeToBoolArray_WebMethod(bool[] p1)
        {
            Assert.AreEqual(true, p1[0]);
            Assert.AreEqual(false, p1[1]);
            Assert.AreEqual(true, p1[2]);
        }

        [TestMethod]
        public void Parameter_BoolArrayIsPassed_ShouldDeserializeToBoolList()
        {
            this._methodCaller.Call(GetWebMethod(), new NameValueCollection
            {
                {"p1", "[true, false, true]"}
            });
        }

        [AjaxMethod]
        public static void Parameter_BoolArrayIsPassed_ShouldDeserializeToBoolList_WebMethod(List<bool> p1)
        {
            Assert.AreEqual(true, p1[0]);
            Assert.AreEqual(false, p1[1]);
            Assert.AreEqual(true, p1[2]);
        }

        [TestMethod]
        public void Parameter_DoubleIsPassed_ShouldDeserializeToDouble()
        {
            this._methodCaller.Call(GetWebMethod(), new NameValueCollection
            {
                {"p1", "123.232"}
            });
        }

        [AjaxMethod]
        public static void Parameter_DoubleIsPassed_ShouldDeserializeToDouble_WebMethod(double p1)
        {
            Assert.AreEqual(123.232D, p1);
        }

        [TestMethod]
        public void Parameter_DoubleArrayIsPassed_ShouldDeserializeToDoubleArray()
        {
            this._methodCaller.Call(GetWebMethod(), new NameValueCollection
            {
                {"p1", "[123.232, 1, -11.12]"}
            });
        }

        [AjaxMethod]
        public static void Parameter_DoubleArrayIsPassed_ShouldDeserializeToDoubleArray_WebMethod(double[] p1)
        {
            Assert.AreEqual(123.232D, p1[0]);
            Assert.AreEqual(1D, p1[1]);
            Assert.AreEqual(-11.12D, p1[2]);
        }

        [TestMethod]
        public void Parameter_FloatIsPassed_ShouldDeserializeToFloat()
        {
            this._methodCaller.Call(GetWebMethod(), new NameValueCollection
            {
                {"p1", "123.232"}
            });
        }

        [AjaxMethod]
        public static void Parameter_FloatIsPassed_ShouldDeserializeToFloat_WebMethod(float p1)
        {
            Assert.AreEqual(123.232F, p1);
        }

        [TestMethod]
        public void Parameter_FloatArrayIsPassed_ShouldDeserializeToFloatArray()
        {
            this._methodCaller.Call(GetWebMethod(), new NameValueCollection
            {
                {"p1", "[123.232, 1, -11.12]"}
            });
        }

        [AjaxMethod]
        public static void Parameter_FloatArrayIsPassed_ShouldDeserializeToFloatArray_WebMethod(float[] p1)
        {
            Assert.AreEqual(123.232F, p1[0]);
            Assert.AreEqual(1F, p1[1]);
            Assert.AreEqual(-11.12F, p1[2]);
        }

        [TestMethod]
        public void Parameter_IntIsPassed_ShouldDeserializeToInt()
        {
            this._methodCaller.Call(GetWebMethod(), new NameValueCollection
            {
                {"p1", "1"}
            });
        }

        [AjaxMethod]
        public static void Parameter_IntIsPassed_ShouldDeserializeToInt_WebMethod(int p1)
        {
            Assert.AreEqual(1, p1);
        }

        [TestMethod]
        public void Parameter_IntArrayIsPassed_ShouldDeserializeToIntArray()
        {
            this._methodCaller.Call(GetWebMethod(), new NameValueCollection
            {
                {"p1", "[1, 2, 3, 555]"}
            });
        }

        [AjaxMethod]
        public static void Parameter_IntArrayIsPassed_ShouldDeserializeToIntArray_WebMethod(int[] p1)
        {
            Assert.AreEqual(1, p1[0]);
            Assert.AreEqual(2, p1[1]);
            Assert.AreEqual(3, p1[2]);
            Assert.AreEqual(555, p1[3]);
        }

        [TestMethod]
        public void Parameter_LongIsPassed_ShouldDeserializeToLong()
        {
            this._methodCaller.Call(GetWebMethod(), new NameValueCollection
            {
                {"p1", "9223372036854770000"}
            });
        }

        [AjaxMethod]
        public static void Parameter_LongIsPassed_ShouldDeserializeToLong_WebMethod(long p1)
        {
            Assert.AreEqual(9223372036854770000L, p1);
        }

        [TestMethod]
        public void Parameter_LongArrayIsPassed_ShouldDeserializeToLongArray()
        {
            this._methodCaller.Call(GetWebMethod(), new NameValueCollection
            {
                {"p1", "[1, 2, 3, -555]"}
            });
        }

        [AjaxMethod]
        public static void Parameter_LongArrayIsPassed_ShouldDeserializeToLongArray_WebMethod(long[] p1)
        {
            Assert.AreEqual(1L, p1[0]);
            Assert.AreEqual(2L, p1[1]);
            Assert.AreEqual(3L, p1[2]);
            Assert.AreEqual(-555L, p1[3]);
        }

        [TestMethod]
        public void Parameter_ShortIsPassed_ShouldDeserializeToShort()
        {
            this._methodCaller.Call(GetWebMethod(), new NameValueCollection
            {
                {"p1", "123"}
            });
        }

        [AjaxMethod]
        public static void Parameter_ShortIsPassed_ShouldDeserializeToShort_WebMethod(short p1)
        {
            Assert.AreEqual(((short) 123), p1);
        }

        [TestMethod]
        public void Parameter_ShortArrayIsPassed_ShouldDeserializeToShortArray()
        {
            this._methodCaller.Call(GetWebMethod(), new NameValueCollection
            {
                {"p1", "[1, 2, 3, -555]"}
            });
        }

        [AjaxMethod]
        public static void Parameter_ShortArrayIsPassed_ShouldDeserializeToShortArray_WebMethod(short[] p1)
        {
            Assert.AreEqual(((short) 1), p1[0]);
            Assert.AreEqual(((short) 2), p1[1]);
            Assert.AreEqual(((short) 3), p1[2]);
            Assert.AreEqual(((short) -555), p1[3]);
        }

        [TestMethod]
        public void Parameter_StringIsPassed_ShouldDeserializeToString()
        {
            this._methodCaller.Call(GetWebMethod(), new NameValueCollection
            {
                {"p1", "dada"}
            });
        }

        [AjaxMethod]
        public static void Parameter_StringIsPassed_ShouldDeserializeToString_WebMethod(string p1)
        {
            Assert.AreEqual("dada", p1);
        }

        [TestMethod]
        public void Parameter_StringArrayIsPassed_ShouldDeserializeToStringArray()
        {
            this._methodCaller.Call(GetWebMethod(), new NameValueCollection
            {
                {"p1", "['dass', 'dada']"}
            });
        }

        [AjaxMethod]
        public static void Parameter_StringArrayIsPassed_ShouldDeserializeToStringArray_WebMethod(string[] p1)
        {
            Assert.AreEqual("dass", p1[0]);
            Assert.AreEqual("dada", p1[1]);
        }

        private static MethodInfo GetWebMethod([CallerMemberName] string memberName = "")
        {
            return typeof (ParametersSerializationTests).GetMethod(memberName + "_WebMethod");
        }
    }
}