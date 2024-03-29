﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ShiftBusiness.Service;
using ShiftBusiness.Hospital;

namespace ShiftManagement.Controllers
{
    public class InitController : Controller
    {
        // GET: Init
        public String Index()
        {
            String temps = @"冯彦强   渤海证券济南英雄山路营业部总经理
刘庆喜   东方证券济南经七路营业部总经理
万  澍   光大证券济南佛山街营业部总经理
孙维家   光大证券烟台胜利路营业部总经理
王  海   广发证券烟台大海阳路营业部总经理
张玉山   广发证券济南经七路路营业部总经理
马  欣   广发证券济南泺源大街营业部总经理
徐超平   广发证券东营济南路营业部总经理
张连生   国泰君安证券临沂沂蒙路营业部总经理   
姜仁东   国信证券烟台西南河路营业部总经理
王玉秋   海通证券济南泉城路营业部总经理
李美玲   海通证券泰安岱宗大街营业部总经理
杨志艺   海通证券烟台解放路营业部总经理
姜  山   海通证券淄博石化营业部总经理
戚思敏   海通证券淄博通济街营业部总经理
梁纯良   恒泰证券济南解放路营业部总经理   
罗  巍   华泰证券济南山大南路营业部总经理 
贺志民   联合证券济南无影山东路营业部总经理  
张华兴   民生证券济南千佛山路营业部总经理   
毕玉国   齐鲁证券公司副总裁
王绪昌   齐鲁证券公司副总裁
孙培国   齐鲁证券公司副总裁
张云伟   齐鲁证券公司办公室主任
吕祥友   齐鲁证券公司人力资源总部总经理
李学军   齐鲁证券公司经纪业务总部总经理
王胜进   齐鲁证券济南解放路营业部总经理
段  勇   齐鲁证券济南北坦南街营业部总经理
曹  青   齐鲁证券济南山大路营业部总经理
张有忠   齐鲁证券济南舜耕路营业部总经理
杜晓洁   齐鲁证券济南文化西路营业部总经理
齐永明   齐鲁证券济南大明湖路营业部总经理
施凯鸣   齐鲁证券济南共青团路营业部总经理
杨卫东   齐鲁证券济南经七路营业部总经理
李丙堂   齐鲁证券济南经十路营业部总经理
周顺远   齐鲁证券济南历山路营业部总经理
王挺东   齐鲁证券济宁古槐路营业部副总经理
晁国庆   齐鲁证券邹城凫山路营业部总经理
梁  军   齐鲁证券济宁红星东路营业部总经理
姜新春   齐鲁证券济宁洸河路营业部总经理
张大伟   齐鲁证券聊城柳园南路营业部总经理
房广斌   齐鲁证券聊城东昌西路营业部总经理
魏玉军   齐鲁证券滨州渤海七路营业部总经理
王  政   齐鲁证券德州三八路营业部总经理
葛爱红   齐鲁证券德州共青团路营业部总经理
郑国防   齐鲁证券公司东营济南路营业部副总经理 
王忠三   齐鲁证券东营西四路营业部总经理
周永军   齐鲁证券东营南一路营业部总经理
闫立新   齐鲁证券泰安岱宗大街营业部总经理
房玉峰   齐鲁证券泰安东岳大街营业部总经理
李  泷   齐鲁证券泰安升平街营业部总经理
胡延斌   齐鲁证券新泰府前街营业部总经理
谷祖贤   齐鲁证券威海东城路营业部副总经理
丛日平   齐鲁证券荣成成山大道营业部副总经理
赵锦敏   齐鲁证券威海海滨北路营业部总经理
荣以文   齐鲁证券文登香山路营业部总经理
刘士军   齐鲁证券菏泽双河路营业部总经理
周  健   齐鲁证券莱芜鲁中东大街营业部总经理
陶新燕   齐鲁证券莱芜鲁中西大街营业部副总经理
王秀民   齐鲁证券莱芜钢都大街营业部总经理
刘敬斌   齐鲁证券临沂解放路营业部总经理   
王  黎   齐鲁证券日照黄海二路营业部总经理  
张肇平   齐鲁证券潍坊东风西街营业部副总经理
李春廷   齐鲁证券寿光公园北街营业部总经理
商鸿军   齐鲁证券潍坊东风东街营业部总经理
张志刚   齐鲁证券潍坊四平路营业部总经理
袁承顺   齐鲁证券潍坊新华路营业部总经理
姜学茹   齐鲁证券烟台北马路营业部副总经理
孙茂敏   齐鲁证券烟台南大街营业部总经理
于常军   齐鲁证券烟台环山路营业部总经理
曲延森   齐鲁证券烟台开发区长江路营业部总经理
李  军   齐鲁证券烟台牟平营业部总经理
卫建宏   齐鲁证券龙口环城北路营业部总经理
张润桥   齐鲁证券蓬莱钟楼北路营业部总经理
陈志伟   齐鲁证券枣庄青檀中路营业部副总经理
夏  勇   齐鲁证券枣庄文化中路营业部副总经理
刘  晶   齐鲁证券淄博新村西路营业部副总经理
李明唐   齐鲁证券淄博桓公路营业部总经理
赵云霞   齐鲁证券淄博小商品街营业部总经理
张志强   齐鲁证券淄博沿河西路营业部总经理
龚  力   齐鲁证券淄博机场路营业部总经理
吴俊河   齐鲁证券淄博人民西路营业部总经理
尉向东   西部证券潍坊东风东街营业部总经理
刘  超   西南证券济南英贤街营业部总经理
窦  薇   湘财证券济南马鞍山路营业部总经理
夏星舟   湘财证券济南馆驿街营业部总经理
焦庆星   兴业证券济南山大路营业部总经理
赵  鹏   银泰证券济南大纬二路营业部总经理 
李红英   招商证券济南泉城路营业部总经理  
张云锋   众成证券济南经七路营业部总经理
张新春   中国建银投资证券济南历山路营业部总经理   
于海强   中国建银投资证券威海公园路营业部总经理
张伟建   中国民族证券济南历山路营业部总经理
张华胜   中国银河证券烟台营业部总经理
冷冰岩   中国银河证券济南经七路营业部总经理
李  军   中信建投证券济南经四路营业部总经理
马  俊   中信建投证券济南泺源大街营业部总经理
高  军   中信建投证券烟台青年路营业部总经理
夏景科   中信建投证券淄博中心路营业部总经理
赵俊云   中信万通证券滨州黄河二路营业部总经理   
卢  布   中信万通证券滨州黄河五路营业部总经理  
张桂峰   中信万通证券济宁洸河路营业部总经理
宋春辉   中信万通证券临沂沂蒙路营业部总经理
倪新和   中信万通证券烟台南大街营业部总经理
薛玉山   中信万通证券淄博共青团西路营业部总经理
张向阳   中信万通证券淄博美食街营业部总经理  
董  衡   中信万通证券潍坊四平路营业部总经理
张洪林   中信万通证券东营济南路营业部总经理";
            var temps2 = @"王惠敏   鲁能金穗期货公司总经理
徐国强   鲁能金穗期货公司副总经理
鲁能金穗期货公司中层以上工作人员
刘呼声   鲁证期货公司总经理
李学魁   鲁证期货公司副总经理
刘运之   鲁证期货公司副总经理
潘福华   鲁证期货公司财务总监
李喜生   鲁证期货公司业务总监
鲁证期货公司中层以上工作人员
杨峰   齐鲁证券公司监事会主席
钟金龙   齐鲁证券公司合规总监
孙日谦   齐鲁证券公司党总支书记
王晓燕   齐鲁证券公司办公室副主任
张晖   齐鲁证券公司党群工作部总经理
胡增勇   齐鲁证券公司人力资源总部副总经理
王丽敏   齐鲁证券公司计划财务总部副总经理
孙豪志   齐鲁证券公司经纪业务总部副总经理
韩亭德   齐鲁证券公司客户服务部总经理
张勇   齐鲁证券公司信息技术总部总经理
叶欣   齐鲁证券公司投资银行总部济南投行业务负责人
谷琛   齐鲁证券公司证券投资部总经理
李健   齐鲁证券公司资产管理部总经理
潘焕焕   齐鲁证券公司金融创新部总经理
张宗旺   齐鲁证券公司固定收益部总经理
胡伟东   齐鲁证券公司研究所所长
孙海昕   齐鲁证券公司登记结算部副总经理
张维光   齐鲁证券公司合规管理总部总经理
李恒第   齐鲁证券公司风险控制部副总经理
安铁   齐鲁证券公司审计稽核部总经理
亓益峰   齐鲁证券公司后勤保障部总经理
李翔宏   齐鲁证券金泰信公司董事长";
            String[] a = temps2.Split('\n');
            EmployeeService service = new EmployeeService();
            DepartmentService departs  = new DepartmentService();

            foreach (var item in a)
            {
                String[] names = item.Split(' ');
                if (names.Length > 0)
                {
                    //add new person;
                    Employee emp = service.Create();
                    emp.Name = names[0];
                    emp.IdentityNo = "370202198002011022";
                    emp.WorkNo = "36-988";
                    emp.CellPhone = "13905321025";
                    emp.officePhone = "80881254";
                    emp.DepartmentId = 1021;
                    service.Insert(emp);
                   
                }
            }
            return "Success";
        }
    }
}