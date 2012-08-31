using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace Utils
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void NotifyPropertyChanged( string propertyName )
        {
            if ( this.PropertyChanged != null )
                this.PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );

        }
        public virtual void NotifyPropertyChanged( Expression<Func<object>> property )
        {
            MemberExpression memberExpression;
            if ( property.Body is UnaryExpression )
                memberExpression = ( property.Body as UnaryExpression ).Operand as MemberExpression;
            else
                memberExpression = property.Body as MemberExpression;

            if ( memberExpression == null )
                Debug.Assert( false, "It must not happen" );

            var propertyInfo = memberExpression.Member as PropertyInfo;

            if ( propertyInfo == null )
                Debug.Assert( false, "It must not happen" );

            this.NotifyPropertyChanged( propertyInfo.Name );
        }
    }
}
