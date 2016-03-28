using System;
using System.Collections.Generic;

namespace Gabriel.MenuExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var listTc = InitData();
            var depHelper = new DepartmentHelper(listTc);
            var tempList = depHelper.CreatMenu();
            foreach (var item in tempList)
            {
                Console.WriteLine("{0}--Level:{1}--Id:{2}--Name:{3}--ParentId:{4}--SortId:{5}", BlankSpace(item.Level), item.Level, item.Id, item.Name, item.ParentId, item.SortId);
            }
            Console.ReadKey();
        }
        private static List<Department> InitData()
        {
            List<Department> listTc = new List<Department>
            {
                new Department(1, "财务部", 2) {SortId = 99},
                new Department(2, "公司总部", 0),
                new Department(3, "财务组1", 1),
                new Department(4, "财务组2", 1),
                new Department(5, "研发部", 2) {SortId = 98},
                new Department(6, "研发组1", 5),
                new Department(7, "研发组2", 5),
                new Department(8, "研发组3", 5),
                new Department(9, "业务部", 2),
                new Department(10, "业务组1", 9),
                new Department(11, "业务组2", 9),
                new Department(12, "业务组3", 9),
                new Department(13, "研发组1第一小组", 6) {SortId = 99},
                new Department(14, "业务组1第一小组", 10),
                new Department(15, "研发组1第二小组", 6),
                new Department(16, "研发组1第二小组1", 15),
                new Department(17, "研发组1第二小组2", 15),
                new Department(18, "研发组1第二小组2测试1", 17)
            };
            return listTc;
        }
        /// <summary>
        /// 空格缩进
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        private static string BlankSpace(int level)
        {
            return "".PadLeft(level * 2, ' ');
        }
    }
}
