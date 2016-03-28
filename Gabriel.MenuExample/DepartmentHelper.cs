using System.Collections.Generic;
using System.Linq;

namespace Gabriel.MenuExample
{
    /// <summary>
    /// 创建企业组织结构树形结构目录
    /// 应用递归算法案例-DepartmentsTree(树形结构目录)
    /// 页面导航-企业组织结构等
    /// 参考：
    /// ASP.Net应用递归算法案例
    /// http://blog.csdn.net/zjk20108023/article/details/44597741
    /// </summary>
    public class DepartmentHelper
    {
        public List<Department> ListTc;
        private readonly List<Department> _tempList = new List<Department>();
        //单位个数
        private readonly int _departmentCount;
        public DepartmentHelper(List<Department> listTc)
        {
            ListTc = listTc;
            _departmentCount = listTc.Count;
        }
        #region 创建树形结构目录
        /// <summary>
        /// 创建树形结构目录
        /// </summary>
        /// <returns></returns>
        public List<Department> CreatMenu()
        {
            AddLevel();
            SortByLevel();
            SortMenu(ListTc);
            return _tempList;
        }
        #endregion

        #region 目录排序-通过调整层级排序的结果生成目录
        private void SortMenu(List<Department> list)
        {
            if (list == null) return;
            if (_departmentCount == _tempList.Count) return;
            foreach (var item in list)
            {
                if (_tempList.Contains(item))
                {
                    continue;
                }
                _tempList.Add(item);
                var subList = GetSubItem(item.Id);
                SortMenu(subList);
            }
        }

        private List<Department> GetSubItem(int id)
        {
            return ListTc.FindAll(e => e.ParentId == id);
        }
        #endregion

        #region 添加层级-当前单位的级别数
        /// <summary>
        /// 添加层级
        /// </summary>
        private void AddLevel()
        {
            foreach (var item in ListTc)
            {
                item.Level = GetLevel(item, 0);
            }
        }

        private int GetLevel(Department tc, int level)
        {
            var t = ListTc.Find(o => o.Id == tc.ParentId);
            if (t != null)
            {
                level++;
                return GetLevel(t, level);
            }
            return level;
        }

        #endregion

        #region 按照层级排序
        /// <summary>
        /// 按照层级排序
        /// </summary>
        private void SortByLevel()
        {
            ListTc.Sort(CompareByLevel);
        }
        /// <summary>
        /// 排序规则：从小到大
        /// 层级--排序ID--DepartmentID
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int CompareByLevel(Department x, Department y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                return 1;
            }
            if (y == null)
            {
                return -1;
            }
            if (x.Level > y.Level)
            {
                return 1;
            }
            if (x.Level == y.Level && x.SortId > y.SortId)
            {
                return 1;
            }
            if (x.Level == y.Level && x.SortId == y.SortId && x.Id > y.Id)
            {
                return 1;
            }
            return -1;
        }

        #endregion
    }
}