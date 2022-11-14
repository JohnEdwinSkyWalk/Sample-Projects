
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace JoEdAngular2;



    public static class AllMailsService
    {
            public static IEnumerable<AllMailsModel> Mails()
        {
            List<AllMailsModel> mailsModels = new List<AllMailsModel>();
            mailsModels.Add(new AllMailsModel{userId= 1,id=55,title="San",body = "Sangyoung"});
            mailsModels.Add(new AllMailsModel{userId= 2,id=44,title="San1",body = "Sangyoung L1"});
            mailsModels.Add(new AllMailsModel{userId= 3,id=33,title="San2",body = "Sangyoung M2"});
            mailsModels.Add(new AllMailsModel{userId= 4,id=22,title="San3",body = "Sangyoung K3"});
            mailsModels.Add(new AllMailsModel{userId= 5,id=21,title="San4",body = "Sangyoung L4"});
            return mailsModels;
        }
    }

