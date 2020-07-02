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
    unsafe class ETModel_UIComponent_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(ETModel.UIComponent);

            field = type.GetField("Camera", flag);
            app.RegisterCLRFieldGetter(field, get_Camera_0);
            app.RegisterCLRFieldSetter(field, set_Camera_0);


        }



        static object get_Camera_0(ref object o)
        {
            return ((ETModel.UIComponent)o).Camera;
        }
        static void set_Camera_0(ref object o, object v)
        {
            ((ETModel.UIComponent)o).Camera = (UnityEngine.Camera)v;
        }


    }
}
