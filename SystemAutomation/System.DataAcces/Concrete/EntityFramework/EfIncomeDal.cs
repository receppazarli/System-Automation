using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IlimYayma.DataAcces.Abstract;
using IlimYayma.DataAcces.Concrete.EntityFramework;
using IlimYayma.Entities.Concrete;

namespace IlimYayma.DataAcces.Concrete
{
    public class EfIncomeDal : EfEntityRepositoryBase<Income, SystemContext>, IIncomeDal
    {
        //    public string DenemeList()
        //    {
        //        using (IlimYaymaContext context =new IlimYaymaContext())
        //        {
        //            var entity = from i in context.Incomes
        //                join e in context.Employees on i.CreateUser equals e.Id
        //                join it in context.IncomeTypes on i.IncomeTypesId equals it.Id
        //                join p in context.People on i.GiverPersonId equals p.Id
        //                join t in context.Type1 on i.SpeciesId equals t.Id
        //                join mb in context.MoneyBoxes on i.MoneyBoxId equals mb.Id
        //                select new
        //                {
        //                    GelirId = i.Id,
        //                    OluşturanKullancı = e.FirstName + " " + e.LastName,
        //                    OluşturmaTarihi = i.CreateDate,
        //                    SonKullananKişi = e.FirstName + " " + e.LastName,
        //                    SonKullanmaTarihi = i.LastUpDate,
        //                    GelirTürü = it.IncomeName,
        //                    YardımıYapanKişi = p.FirstName + " " + p.LastName,
        //                    YardımıAlanPersonel = e.FirstName + " " + e.LastName,
        //                    Tür = t.TypeName + "(" + t.Unit + ")",
        //                    YardımınAlındığıTarih = i.DateReceived,
        //                    Kumbara = mb.MoneyBoxName,
        //                    Dönem = i.Semester
        //                };

        //            return entity.ToString();
        //        }

        //    }
    }
}
