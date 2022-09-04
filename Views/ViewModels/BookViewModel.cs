using System.Collections.Generic;

public abstract class PaginationViewmODEL : BookViewModel<BaseEntity> { }
public abstract class BookViewModel : BookViewModel<BaseEntity> { }

public abstract class BookViewModel<T> : ViewItem {

    public int PageNumber { get; set; } = 1;
    public int TotalResults { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int TotalPages
    {
        get
        {
            return ((TotalResults % PageSize) == 0) ? ((int)(TotalResults / PageSize)) : (1 + ((int)((TotalResults - ((TotalResults % PageSize))) / PageSize)));
        }
    }


    public IEnumerable<T> Results { get; set; }
};
