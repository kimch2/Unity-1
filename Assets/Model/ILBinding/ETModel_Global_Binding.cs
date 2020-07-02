using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Reflection;
using ILRuntime.CLR.Utils;

namespace ILRuntime.Runtime.Generated
{
    unsafe class ETModel_Global_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(ETModel.Global);
            args = new Type[]{};
            method = type.GetMethod("get_LoadProjectName", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_LoadProjectName_0);

            field = type.GetField("LoadSceneAssetsbundle", flag);
            app.RegisterCLRFieldGetter(field, get_LoadSceneAssetsbundle_0);
            app.RegisterCLRFieldSetter(field, set_LoadSceneAssetsbundle_0);


        }


        static StackObject* get_LoadProjectName_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = ETModel.Global.LoadProjectName;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }


        static object get_LoadSceneAssetsbundle_0(ref object o)
        {
            return ETModel.Global.LoadSceneAssetsbundle;
        }
        static void set_LoadSceneAssetsbundle_0(ref object o, object v)
        {
            ETModel.Global.LoadSceneAssetsbundle = (System.Collections.Generic.List<System.String>)v;
        }


    }
}
