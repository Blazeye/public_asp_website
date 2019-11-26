using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using SkuAppDomain.Abstract;
using SkuAppDomain.Concrete;
using SkuAppDomain.Entities;
using SkuAppDomain.EntityFrameworkTest;
using SkuApplication.Abstract;
using SkuApplication.Controllers;

namespace SkuApplication.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {

            kernel.Bind<IUserRepository>().To<EFUserRepository>();

            kernel.Bind(typeof(ICommentRepository<Comment>), typeof(GenericRepository<Comment>)).To(typeof(CommentRepository<Comment>)).WithConstructorArgument("repository");

            kernel.Bind(typeof(INavRepository<Category>), typeof(GenericRepository<Category>)).To(typeof(NavRepository<Category>)).WithConstructorArgument("repository");

            kernel.Bind(typeof(IMessageRepository<Message>), typeof(GenericRepository<Message>)).To(typeof(MessageRepository<Message>)).WithConstructorArgument("repository");
            kernel.Bind(typeof(IMessageRepository<Comment>), typeof(GenericRepository<Comment>)).To(typeof(MessageRepository<Comment>)).WithConstructorArgument("repository");

            kernel.Bind<IGenericRepository<Category>>().To<GenericRepository<Category>>();
            kernel.Bind<IGenericRepository<Color>>().To<GenericRepository<Color>>();
            kernel.Bind<IGenericRepository<Comment>>().To<GenericRepository<Comment>>();
            kernel.Bind<IGenericRepository<Message>>().To<GenericRepository<Message>>();
            kernel.Bind<IGenericRepository<Role>>().To<GenericRepository<Role>>();
            kernel.Bind<IGenericRepository<Subject>>().To<GenericRepository<Subject>>();
            kernel.Bind<IGenericRepository<User>>().To<GenericRepository<User>>();

            kernel.Bind<IUserController>().To<UserController>();

            kernel.Bind<IDbContext>().To<EFDbContext>();
            // put bindings here
        }
    }
}