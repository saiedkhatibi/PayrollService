using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;

namespace PayrollService.DIContainer
{
    public class DIResolver : IDependencyResolver
    {
        private readonly IUnityContainer _unityContainer;

        public DIResolver( )
        {
        }

        public DIResolver( IUnityContainer unityContainer )
        {
            _unityContainer = unityContainer;
        }
        public IDependencyScope BeginScope( )
        {
            var newChildContainer = _unityContainer.CreateChildContainer( );
            return new DIResolver( newChildContainer );
        }

        public void Dispose( )
        {
        }

        public object GetService( Type serviceType )
        {
            try
            {
                return _unityContainer.Resolve( serviceType );
            }
            catch( ResolutionFailedException )
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices( Type serviceType )
        {
            try
            {
                return _unityContainer.ResolveAll( serviceType );
            }
            catch( ResolutionFailedException )
            {
                return null;
            }
        }
    }
}