using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Linq;
using System.Reflection;

namespace Connector.SDK.Injector.CustomScopes
{
    public class OuterScopedLifestyle : AsyncScopedLifestyle
    {
        public OuterScopedLifestyle() : base() { }

        // By making the length of this lifestyle one bigger than Lifestyle.Scoped, prevent
        // OuterScopedLifestyle instances from depending on Lifestyle.Scope instances,
        // which could obviously lead to problems.
        //public override int Length => Lifestyle.Scoped.Length + 1;

        protected override Func<Scope> CreateCurrentScopeProvider(Container container)
            => () => this.GetOuterScope(Lifestyle.Scoped.GetCurrentScope(container));

        protected override Scope GetCurrentScopeCore(Container container)
            => this.GetOuterScope(Lifestyle.Scoped.GetCurrentScope(container));

        // Walk the scope-stack to find the outer-most scope.
        private Scope GetOuterScope(Scope scope)
        {
            if (scope == null) return null;

            Scope getLastUsableScope(Scope current)
            {

                Scope parentScope = this.GetParentScope(current);
                bool parentIsUsable = parentScope != null;// && !this.GetDisposed(parentScope);

                if (parentIsUsable)
                    return getLastUsableScope(parentScope);
                else
                    return current;
            }

            return getLastUsableScope(scope);
        }

        // Unfortunately, the Scope.ParentScope and Scope.Disposed properties are internal in Simple Injector v4.0.
        // We need to use reflection to get to it.
        private PropertyInfo getProperty(string Name) =>
            typeof(Scope)
                .GetProperties(BindingFlags.Instance | BindingFlags.NonPublic)
                .Single(p => p.Name == Name);

        private Scope GetParentScope(Scope scope) => (Scope)this.getProperty("ParentScope").GetValue(scope);

        private bool GetDisposed(Scope scope) => (bool)this.getProperty("Disposed").GetValue(scope);
    }
}