using Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Infrastructure.AcessoDados
{
    public class Padrao<TEntity> : IService<TEntity>, IDisposable where TEntity : BaseEntity
    {

        public IConfiguration Configuration { get; }

        private IConfigurationSection stringDeConexao;

        SqlConnection _conexao;
        protected DbDataReader _dbDataReader;
        protected DbCommand _dbCommand;


        public Padrao(IConfiguration configuration) : base()
        {
            Configuration = configuration;

            stringDeConexao = Configuration.GetSection("AppSettings:BANCO");

            _dbCommand = new SqlCommand();
        }

        protected void CreateCommand(CommandType commandType, string commandText)
        {
            this._dbCommand.CommandType = commandType;
            this._dbCommand.CommandText = commandText;
            this._dbCommand.CommandTimeout = int.MaxValue;
        }


        public virtual List<TEntity> Consultar(TEntity objEntity_)
        {

            _conexao = new SqlConnection(stringDeConexao.Value);
            _conexao.Open();
            this._dbCommand.Connection = _conexao;

            return this.Select(objEntity_);
        }
        public virtual TEntity Criar(TEntity objEntity_)
        {

            _conexao = new SqlConnection(stringDeConexao.Value);
            _conexao.Open();
            this._dbCommand.Connection = _conexao;

            return this.Select(objEntity_).FirstOrDefault();
        }

        public virtual TEntity Atualizar(TEntity objEntity_)
        {

            _conexao = new SqlConnection(stringDeConexao.Value);
            _conexao.Open();
            this._dbCommand.Connection = _conexao;

            return this.Select(objEntity_).FirstOrDefault();
        }

        private List<TEntity> Select(TEntity objEntity_)
        {
            List<TEntity> _objBaseDTOList = new List<TEntity>();

            try
            {


                this._dbDataReader = this._dbCommand.ExecuteReader();

                if (this._dbDataReader.HasRows)
                {
                    while (this._dbDataReader.Read())                    {
                      
                        this.ConvertFromDB(objEntity_);

                        _objBaseDTOList.Add(objEntity_);
                    }
                }
            }
            finally
            {
                if ((this._dbDataReader != null) && (!this._dbDataReader.IsClosed))
                {
                    this._dbDataReader.Close();
                }

                objEntity_ = null;
            }

            return _objBaseDTOList;
        }
        public virtual int Executar()
        {
            _conexao = new SqlConnection(stringDeConexao.Value);
            _conexao.Open();
            this._dbCommand.Connection = _conexao;

            return _dbCommand.ExecuteNonQuery();
        }

        #region ParamIn
        protected void AddInParamString(string name_, string value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.String;
            dbParameter.Direction = ParameterDirection.Input;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected void AddInParamGuid(string name_, Guid value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.Guid;
            dbParameter.Direction = ParameterDirection.Input;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected void AddInParamByte(string name_, Byte? value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.Byte;
            dbParameter.Direction = ParameterDirection.Input;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected void AddInParamInt16(string name_, Int16? value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.Int16;
            dbParameter.Direction = ParameterDirection.Input;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected void AddInParamInt32(string name_, Int32? value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.Int32;
            dbParameter.Direction = ParameterDirection.Input;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected void AddInParamInt64(string name_, Int64? value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.Int64;
            dbParameter.Direction = ParameterDirection.Input;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected void AddInParamDecimal(string name_, Decimal? value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.Decimal;
            dbParameter.Direction = ParameterDirection.Input;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected void AddInParamSingle(string name_, Single? value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.Single;
            dbParameter.Direction = ParameterDirection.Input;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected void AddInParamDouble(string name_, Double? value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.Double;
            dbParameter.Direction = ParameterDirection.Input;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected void AddInParamBoolean(string name_, Boolean? value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.Boolean;
            dbParameter.Direction = ParameterDirection.Input;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;



            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected void ClearParameters()
        {
            this._dbCommand.Parameters.Clear();
        }

        protected void AddInParamBinary(string name_, byte[] value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.Binary;
            dbParameter.Direction = ParameterDirection.Input;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected void AddInParamDateTime(string name_, DateTime? value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.DateTime;
            dbParameter.Direction = ParameterDirection.Input;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        #endregion

        #region ParamOut



        protected void AddOutParamString(string name_, string value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.String;
            dbParameter.Direction = ParameterDirection.Output;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;
            dbParameter.Size = int.MaxValue;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected void AddOutParamGuid(string name_, Guid? value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.Guid;
            dbParameter.Direction = ParameterDirection.Output;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;
            dbParameter.Size = int.MaxValue;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected void AddOutParamByte(string name_, Byte? value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.Byte;
            dbParameter.Direction = ParameterDirection.Output;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;
            dbParameter.Size = int.MaxValue;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected void AddOutParamInt16(string name_, Int16? value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.Int16;
            dbParameter.Direction = ParameterDirection.Output;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;
            dbParameter.Size = int.MaxValue;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected void AddOutParamInt32(string name_, Int32? value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.Int32;
            dbParameter.Direction = ParameterDirection.Output;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;
            dbParameter.Size = int.MaxValue;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected void AddOutParamInt64(string name_, Int64? value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.Int64;
            dbParameter.Direction = ParameterDirection.Output;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;
            dbParameter.Size = int.MaxValue;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected void AddOutParamDecimal(string name_, Decimal? value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.Decimal;
            dbParameter.Direction = ParameterDirection.Output;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;
            dbParameter.Size = int.MaxValue;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected void AddOutParamSingle(string name_, Single? value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.Single;
            dbParameter.Direction = ParameterDirection.Output;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;
            dbParameter.Size = int.MaxValue;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected void AddOutParamDouble(string name_, Double? value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.Double;
            dbParameter.Direction = ParameterDirection.Output;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;
            dbParameter.Size = int.MaxValue;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected void AddOutParamBoolean(string name_, Boolean? value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.Boolean;
            dbParameter.Direction = ParameterDirection.Output;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;
            dbParameter.Size = int.MaxValue;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected void AddOutParamBinary(string name_, byte[] value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.Binary;
            dbParameter.Direction = ParameterDirection.Output;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;
            dbParameter.Size = int.MaxValue;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected void AddOutParamDateTime(string name_, DateTime? value_)
        {
            DbParameter dbParameter = this._dbCommand.CreateParameter();

            dbParameter.DbType = DbType.DateTime;
            dbParameter.Direction = ParameterDirection.Output;
            dbParameter.ParameterName = this.SetParamName(name_);
            dbParameter.Value = value_;
            dbParameter.Size = int.MaxValue;

            this._dbCommand.Parameters.Add(dbParameter);
        }

        protected string SetParamName(string name_)
        {
            string _name = name_;


            return _name;
        }

        #endregion


        protected virtual void ConvertFromDB(TEntity objBaseDTO_)
        {
            PropertyInfo[] _objPropertyInfoArray = typeof(TEntity).GetProperties();

            Attribute[] _objCustomAttributeArray = null;
            ColumnInDataBase _objColumnInDataBase = null;

            string _columnName = string.Empty;
            Guid _objGuid;

            try
            {
                foreach (PropertyInfo _objProperty in _objPropertyInfoArray)
                {
                    _objCustomAttributeArray = Attribute.GetCustomAttributes(_objProperty);

                    if ((_objCustomAttributeArray != null) && (_objCustomAttributeArray.Length > 0))
                    {
                        foreach (Attribute _objAttribute in _objCustomAttributeArray)
                        {
                            if (_objAttribute is ColumnInDataBase)
                            {
                                _objColumnInDataBase = (ColumnInDataBase)_objAttribute;
                                _columnName = _objColumnInDataBase.ColumnName();
                                break;
                            }
                        }
                    }
                    else
                    {
                        _columnName = _objProperty.Name;
                    }

                    if (this.HasColumn(_columnName))
                    {
                        try
                        {
                            if (!this._dbDataReader.GetValue(_dbDataReader.GetOrdinal(_columnName)).GetType().Name.Equals("DBNull", StringComparison.InvariantCultureIgnoreCase))
                            {
                                switch (this._dbDataReader.GetValue(_dbDataReader.GetOrdinal(_columnName)).GetType().Name)
                                {

                                    case "String":

                                        _objProperty.SetValue(objBaseDTO_, Convert.ToString(this._dbDataReader[_columnName]));

                                        break;
                                    case "Guid":
                                        if (Guid.TryParse(Convert.ToString(this._dbDataReader[_columnName]), out _objGuid))
                                            _objProperty.SetValue(objBaseDTO_, _objGuid);
                                        break;
                                    case "Byte":
                                        _objProperty.SetValue(objBaseDTO_, Convert.ToByte(this._dbDataReader[_columnName]));
                                        break;
                                    case "Int16":
                                        _objProperty.SetValue(objBaseDTO_, Convert.ToInt16(this._dbDataReader[_columnName]));
                                        break;
                                    case "Int32":
                                        _objProperty.SetValue(objBaseDTO_, Convert.ToInt32(this._dbDataReader[_columnName]));
                                        break;
                                    case "Int64":
                                        _objProperty.SetValue(objBaseDTO_, Convert.ToInt64(this._dbDataReader[_columnName]));
                                        break;
                                    case "Decimal":
                                        _objProperty.SetValue(objBaseDTO_, Convert.ToDecimal(this._dbDataReader[_columnName]));
                                        break;
                                    case "Single":
                                        _objProperty.SetValue(objBaseDTO_, Convert.ToSingle(this._dbDataReader[_columnName]));
                                        break;
                                    case "Double":
                                        _objProperty.SetValue(objBaseDTO_, Convert.ToDouble(this._dbDataReader[_columnName]));
                                        break;
                                    case "Boolean":
                                        _objProperty.SetValue(objBaseDTO_, Convert.ToBoolean(this._dbDataReader[_columnName]));
                                        break;
                                    case "Binary":
                                        _objProperty.SetValue(objBaseDTO_, Convert.ToByte(this._dbDataReader[_columnName]));
                                        break;
                                    case "DateTime":
                                        _objProperty.SetValue(objBaseDTO_, Convert.ToDateTime(this._dbDataReader[_columnName]));
                                        break;
                                }
                            }
                        }
                        catch (Exception _objException)
                        {
                            objBaseDTO_.BadRequest = true;
                            objBaseDTO_.MensagemErroValidator.Add(string.Concat("Coluna [", _columnName, "] -> ", _objException.Message));                           
                        }
                    }
                }
            }
            finally
            {
                _objPropertyInfoArray = null;

                _objCustomAttributeArray = null;
                _objColumnInDataBase = null;

                _columnName = null;
            }
        }
        protected bool HasColumn(string columnName_)
        {
            if (this._dbDataReader.CanGetColumnSchema())
            {
                foreach (DbColumn _objDbColumn in this._dbDataReader.GetColumnSchema())
                {
                    if (_objDbColumn.ColumnName.Equals(columnName_, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return true;
                    }
                }

                return false;
            }

            return true;
        }

        public void Dispose()
        {

            if (_conexao.State == ConnectionState.Open && null != _conexao)
            {
                _conexao.Close();
            }

            _conexao = null;
            _dbDataReader = null;
            _dbCommand = null;

        }



    }
}
