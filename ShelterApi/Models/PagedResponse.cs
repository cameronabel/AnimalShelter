namespace ShelterApi.Models;

public class PagedResponse<T> : Response<T>
{
  public int PageNumber { get; set; }
  public int PageSize { get; set; }
  public int TotalPages { get; set; }
  public int TotalRecords { get; set; }
  public PagedResponse(T data, int pageNumber, int pageSize, int totalRecords)
  {
    this.PageNumber = pageNumber;
    this.PageSize = pageSize;
    this.Data = data;
    this.TotalRecords = totalRecords;
    this.TotalPages = totalRecords > 0 ? Convert.ToInt32(Math.Ceiling((double)totalRecords / pageSize)) : 0;
    this.Message = null;
    this.Succeeded = true;
    this.Errors = null;
  }
}
