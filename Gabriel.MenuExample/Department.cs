namespace Gabriel.MenuExample
{
    public class Department
    {
        public Department(int id, string name, int parentid)
        {
            this.Id = id;
            this.Name = name;
            this.ParentId = parentid;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        /// <summary>
        /// 排序ID:*数字，越小越向前 
        /// </summary>
        public int SortId { get; set; }
        /// <summary>
        /// 层级位置
        /// </summary>
        public int Level { get; set; }

    }
}