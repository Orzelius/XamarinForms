﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Authorizator.ViewModels {
    public abstract class BaseViewModel : BindableObject {
        public void RaisePropertyChanged<T>(Expression<Func<T>> property) {
            var name = GetMemberInfo(property).Name;
            OnPropertyChanged(name);
        }

        private MemberInfo GetMemberInfo(Expression expression) {
            MemberExpression operand;
            LambdaExpression lambdaExpression = (LambdaExpression)expression;
            if (lambdaExpression.Body as UnaryExpression != null) {
                UnaryExpression body = (UnaryExpression)lambdaExpression.Body;
                operand = (MemberExpression)body.Operand;
            }
            else {
                operand = (MemberExpression)lambdaExpression.Body;
            }
            return operand.Member;
        }
    }
}
