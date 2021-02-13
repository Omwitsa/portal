using System;

namespace Unisol.Web.Common.Process
{

    public class ReturnData<T>
    {
        public ReturnData()
        {
            Success = true;
            NotAuthenticated = false;
        }
        public bool Success { set; get; }
        public bool NotAuthenticated { get; set; }
        public string Message { set; get; }
        public T Data { set; get; }
        public int? TotalItems { set; get; }
        public Error Error { get; set; }
    }

    public class Error
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public Error(Exception ex)
        {
            Code = 500;
            Message = ErrorMessangesHandler.ExceptionMessage(ex);
        }
    }

	public class QueryResults
	{
		public string Balance { get; set; }
		public DateTime? Date { get; set; }
	}

}
