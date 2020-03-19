using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mall.DAL
{
    public class SQLBasis
    {
        private Type type;
        private string TNamestr;
        private string sql;
        private string sqllast;

        public SQLBasis(Type type)
        {
            this.type = type;
            string Tname = type.Name;

        }

        public SQLBasis(string TNamestr)
        {
            this.TNamestr = TNamestr;
        }


        /// <summary>
        /// 之间
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public void Between(string colname, string v1, string v2)
        {
            string andsql = string.Format(@" and {0} between '{1}' and '{2}'", colname, v1, v2);
            sql = sql + andsql;
        }




        /// <summary>
        /// 等于
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public void And(string colname, string v1)
        {
            string andsql = string.Format(@"and {0}={1}", colname, v1);
            sql = sql + andsql;
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="v1">字段名</param>
        /// <param name="v2">asc，desc</param>
        public void Orderby(string v1, string v2)
        {
            sqllast = string.Format(@"Order by {0} {1}", v1, v2);
        }


        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        public void Like(string colname, string v1)
        {
            string andsql = string.Format(@"and {0} like '%{1}%'", colname, v1);
            sql = sql + andsql;
        }

        /// <summary>
        /// 更小
        /// </summary>
        /// <param name="v1">model的属性 </param>
        /// <param name="v2">对比的值</param>
        public void Smaller(string colname, string v1)
        {
            string andsql = string.Format(@"and {0}<{1} ", colname, v1);
        }


        /// <summary>
        /// 手写的sql语句
        /// </summary>
        /// <param name="sqlnext"></param>
        public void Sql(string sqlnext)
        {
            sql = sql + sqlnext;
        }


        /// <summary>
        /// 在某段时间内
        /// </summary>
        /// <param name="minColname"></param>
        /// <param name="maxColname"></param>
        /// <param name="minT"></param>
        /// <param name="maxT"></param>
        public void InTime(string minColname, string maxColname, string minT, string maxT)
        {
            string andsql = string.Format($"and (({minColname}<'{maxT}' and  {maxColname} >'{minT}') or  ({maxColname}<'{maxT}' and  {minColname} >'{minT}'))");
            sql = sql + andsql;
        }


        /// <summary>
        /// 更大
        /// </summary>
        /// <param name="v1">model的属性 </param>
        /// <param name="v2">对比的值</param>
        public void Bigger(string colname, string v1)
        {
            string andsql = string.Format(@"and {0}<{1}", colname, v1);
            sql = sql + andsql;
        }

        /// <summary>
        /// 返回条件语句
        /// </summary>
        /// <returns></returns>
        public string Sqllinq()
        {

            return sql + sqllast;
        }



        public string Tname()
        {
            if (!string.IsNullOrWhiteSpace(TNamestr))
            {
                return TNamestr;
            }
            return type.Name;
        }
    }
}
