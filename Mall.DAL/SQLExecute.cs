using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mall.DAL
{
    public class SQLExecute
    {
        DataBase zJDAL = new DataBase();
        public static int Count<T>(T t)
        {
            Type type = typeof(T);           
            SQLBasis sqlBasis = new SQLBasis("");
            sqlBasis.And("", "");

            return 1;
        }
        public void EG()
        {
            using (DataBase db = new DataBase())
            {
                var _param = new List<object>();                                    //定义ExecuteSqlCommand参数
                _param.Add(1);                                                      //给in条件前面的参数赋值，根据实际情况
                var _in = new object[] { "test@qq.com", "a@gmail.com", "b@163.com" };//in条件
                _param.AddRange(_in);                                               //给in参数赋值
                var sql = "UPDATE users SET islocked={0} WHERE email IN ({1})";
                // .Replace("{1}", _in.Select((v, i) => "{" + (i + 1) + "}").Join(","));//给in条件的增加占位符,{"+(i+1)+"}中的1根据in条件前面有几个占位符而定
                db.Database.ExecuteSqlCommand(sql, _param.ToArray());                    //执行
            }
        }


        /// <summary>
        /// 查找Model 的表
        /// </summary>
        /// <typeparam name="T">Model 名</typeparam>
        /// <param name="sqlBasis"></param>
        /// <returns></returns>

        public List<T> GetAllModel<T>(SQLBasis sqlBasis)
        {
            string sql = sqlBasis.Sqllinq();

            string type = sqlBasis.Tname();

            string sqlwhere = string.Format(@"select * from {0} where 1=1 ", type);

            sqlwhere = sqlwhere + sql;

            return zJDAL.Database.SqlQuery<T>(sqlwhere).ToList();
        }

        /// <summary>
        /// 查找一个model
        /// </summary>
        /// <typeparam name="T">Model 名</typeparam>
        /// <param name="sqlBasis"></param>
        /// <returns></returns>
        public T GetOneModel<T>(SQLBasis sqlBasis)
        {
            string sql = sqlBasis.Sqllinq();

            string type = sqlBasis.Tname();

            string sqlwhere = string.Format(@"select * from {0} where 1=1 ", type);

            sqlwhere = sqlwhere + sql;

            return zJDAL.Database.SqlQuery<T>(sqlwhere).FirstOrDefault();
        }

        public T OneModel<T>(SQLBasis sqlBasis)
        {
            string sql = sqlBasis.Sqllinq();

            string type = sqlBasis.Tname();

            string sqlwhere = string.Format(@"select * from {0} where 1=1 ", type);

            sqlwhere = sqlwhere + sql;

            return zJDAL.Database.SqlQuery<T>(sqlwhere).FirstOrDefault();
        }
        /// <summary>
        /// 总数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlBasis"></param>
        /// <returns></returns>
        public int GetCount<T>(SQLBasis sqlBasis)
        {
            string sql = sqlBasis.Sqllinq();

            string type = sqlBasis.Tname();

            string sqlwhere = string.Format(@"select Count(*) from {0} where 1=1 ", type);

            sqlwhere = sqlwhere + sql;

            int i = 0;
            using (DataBase DB = new DataBase())
            {

                i = Convert.ToInt16(DB.Database.SqlQuery<T>(sqlwhere));
            }
            return i;
        }
    }
}
