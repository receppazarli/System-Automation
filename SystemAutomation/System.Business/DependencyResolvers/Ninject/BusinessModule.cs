using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IlimYayma.Business.Abstract;
using IlimYayma.Business.Concrete;
using IlimYayma.DataAcces.Abstract;
using IlimYayma.DataAcces.Concrete;
using IlimYayma.DataAcces.Concrete.EntityFramework;
using Ninject.Modules;

namespace IlimYayma.Business.DependencyResolvers
{
    public class BusinessModule:NinjectModule
    {
        // Daha kolay bir erişim sağlama için bu şekilde yaptık arayüzde newleme yapma işini bayağı toparladık ve aynı şeyi birdaha 
        //newlenemz diyerek performansta artışa gittik.
        public override void Load()
        {
            Bind<ICityService>().To<CityManager>().InSingletonScope();
            Bind<ICityDal>().To<EfCityDal>().InSingletonScope();

            Bind<IDistrictService>().To<DistrictManager>().InSingletonScope();
            Bind<IDistrictDal>().To<EfDistrictDal>().InSingletonScope();

            Bind<IEmployeeService>().To<EmployeeManager>().InSingletonScope();
            Bind<IEmployeeDal>().To<EfEmployeeDal>().InSingletonScope();

            Bind<IExpenseService>().To<ExpenseManager>().InSingletonScope();
            Bind<IExpenseDal>().To<EfExpenseDal>().InSingletonScope();

            Bind<IExpenseTypeService>().To<ExpenseTypeManager>().InSingletonScope();
            Bind<IExpenseTypeDal>().To<EfExpenseTypeDal>().InSingletonScope();

            Bind<IIncomeService>().To<IncomeManager>().InSingletonScope();
            Bind<IIncomeDal>().To<EfIncomeDal>().InSingletonScope();

            Bind<IIncomeTypeService>().To<IncomeTypeManager>().InSingletonScope();
            Bind<IIncomeTypeDal>().To<EfIncomeTypeDal>().InSingletonScope();

          

            Bind<IPersonService>().To<PersonManager>().InSingletonScope();
            Bind<IPersonDal>().To<EfPersonDal>().InSingletonScope();

            Bind<IType1Service>().To<Type1Manager>().InSingletonScope();
            Bind<IType1Dal>().To<EfType1Dal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

            Bind<IUserAuthorizationService>().To<UserAuthorizationManager>().InSingletonScope();
            Bind<IUserAuthorizationDal>().To<EfUserAuthorizationDal>().InSingletonScope();



        }
    }
}
