using Microsoft.Extensions.DependencyInjection;
using Models.Api.Global.Services;
using Models.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using Tools.Databases;
using Tools.Patterns.Locator;
using Tools.Security.Token;

namespace SuperHeroes.Api.Infrastructure
{
    public sealed class ResourceLocator : LocatorBase
    {
        #region Singleton
        private static ResourceLocator _instance;

        public static ResourceLocator Instance
        {
            get
            {
                return _instance ?? (_instance = new ResourceLocator());
            }
        }

        private ResourceLocator()
        {

        }
        #endregion

        protected override void ConfigureServices(IServiceCollection serviceCollection)
        {

            serviceCollection.AddSingleton<ITokenService, TokenService>(sp => new TokenService("3$HHq@HHBb3DYt*p2yWg$bEgYm=_*^@FtLvNXv^=HWQ4g@py-GPhT!+x=%Ar34jd7+R_6gy_vk%*2*@sY!w%GLQGm6Q!AAK?C6@$#d4Nmd%*^z#Qd%4QTA^s@J#gRemc8Wc6vjY!+#SMq83LHE+^d6n^Dy!8d_-m9esmn3XS6CUEFgN2-Ck_q$SrMv*#tz9AJdvqP9b^hFk$v7jnnZDu#^cyVC8nkCpS9vy7^Hqq9BPazkb3xs4=Hf@kMqf+=q2sfjR6!A+rHR6CLmv-?r+?znz*R-F$jQpXm65wS?t%GU5+PLrGe!w3q^aEbmV5UX+FK4?t*S_6wqU&c!T?9HnW%$UkwEb^%X3G^7CQ+d$maPmUN?N*!+2ct%2+q!L^dg&Qy-Jp5HpKUX+7fsxU@F%Lm9P&eemQ^k#+@MZ+?a=$YqxyvdXWY#vhpb@*-2!DyPv+-3sJ*mXNKf7V2APxBT7cdMXTMw353$mn4UQ&#HJ_xG2D&yHXnfQJ!Ubu+K_=T=*9QGPdvEfzD=+!7MMEvT4Jh$Dt8PG8*dHH6@5d$hZCa%PzP9ys-ChQk3x@%KzEcre=jSZ+vSw*^F9bqUX+cNMSELk@Ps?+hUf7#GCett5L#6XgzMAGrSHDV?yep?CQe%BGbv3fS?Gcx@H8EhCfQ#A8L*m%xgb%y7em6SJU+Ka?^j&!^jhb=V@rb5dVTFdSw7!aPUVYaQ59!*PD2DD4NWGDW$y-p^=a6jdf#*nr=KNww&c+9xvxLBffFSF?3RWk@gmpMHNyycvGc7Getuad$uKpCTD?jeut#wxcPr^qNsb5@p*f6#_qPPp#8sCqC7Sp%tSxAGqR9a4hDr5@L$skYhNCQa5LwkdL#QQA@K**BCpp6TD^zDYcc!xc^ymLZWadju3fBKYjrxSJn8jRf3fYpt+?G9#@Awkey-zVrNL9ar_aVyGstBZM8k5p+un6N!GMRBXVVPfU#RSUz%$&SuNQHytVF*!fbfkHxkvAGJzrYFhee^BzkUJm5NDP3&ejrSYt2b5s%+?atg$7@pucR#+YeG@WMH=uNfGmgM2@&zzeCHFJ?LhPkX*&q$Sqjm6FNtNw7q69sDpCY%7-mYbsuSPwqP=spTFQFQv%_?wr87a9utCLTgN$!7sc+g+nGXE&T5=MZs!+Q5jrL?=nxSsmCwM#vy?G=#$wVcv=c^Ay-Y6k5_vmztZQxvzc?7^e?z+_Zg=AQsH-^_KQ9NsLT-6KM$y5P6&2^5^MUbVvzHj4gFgwTv5hYWE2ELkwFxrb*rvh+vxws_^MuDa5-G5&v#@qb^^N!Vpzjr=cAyRnj@vn5&CDDhxYtKgmU$DVt-drRrfKf@%-GK7BsbBug%$MaGRszt7ZEs^6mNvgYBUE-+fsk^N84x!hpPfHFEbSLm&cJsZG_2Aa3h-CJ=QMd2NZv@QHDuQNDgWZp5ZP4kW!^$uRjYLk4a2HyamHM_y!s!8q%Mmw3DZcr&zxhxrrZVa%&D$txfpbhfX$WzaPGAfXL9%Ypa@LyHXJEs&Z4RjkhaX8Tz=x22CMRBFU-p4MNXXxJaJqBvQqaWT4HjbzSxFfYZGmd@rAK+K#%3ztSWdBx6eBpT4=38#K98#5-$hgtC+h5%mH&#6DqQFwmpK#Q#DQxGBcsvGJ%X!T8E%_x@*Jz+cfQyP?rQ3zhdk7wPyYCP9T%t+9Tpf_EV8dbSRUqsG2%rSH+bY=hRp-*Syw-u+a2h3pnj4Wz9$ADB+4p9Jtfsu*dT%xB=9Pejy7qvVS234UmgPAH%sMR5X@dfdJZ95^EmNrbJQ6m$B_7DRWhWy@JszvxUskcF@j&X9wWK8UUTCAe!#5-u&rW+uZ*aU-&gzdeRBuGLA*_6kr-EyEK*Dy#-ykBC@4SB&dhkr6j_zf*+%N-5yjSPSqJMaAy?EZLmBD#DD4bjjdXYQq7P-@GFUP?ka$39E4TvQH7u-s3XZ#8B5Mr7g&!=T@nATuPX?JuKUYz#G4W6GSxKtP@ceL^p_^%fX5dnNRVm!=2F^BgFf9nwdsPUdJbc6H4Hqhp^5TMUuatn28tJqtkMPshD9x"));
            serviceCollection.AddSingleton<DbProviderFactory>(sp => SqlClientFactory.Instance);
            serviceCollection.AddSingleton<IConnectionInfo, ConnectionInfo>(sp => new ConnectionInfo(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SuperHeroes;User Id=SuperHeroes;Password=SuperHeroes"));
            serviceCollection.AddSingleton<IConnection, Connection>();
            serviceCollection.AddSingleton<IAuthRepository, AuthRepository>();
            serviceCollection.AddSingleton<ISuperHeroesRepository, SuperHeroesRepository>();
        }

        public ITokenService TokenService
        {
            get { return Container.GetService<ITokenService>(); }
        }

        public IAuthRepository AuthRepository
        {
            get { return Container.GetService<IAuthRepository>(); }
        }

        public ISuperHeroesRepository SuperHeroesRepository
        {
            get { return Container.GetService<ISuperHeroesRepository>(); }
        }
    }
}