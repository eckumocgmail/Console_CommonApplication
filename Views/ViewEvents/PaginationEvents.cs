public interface PaginationEvents
{
    public interface DataTableEvents
    {
        
        public void OnPageNumberChanged( int PageNumber );
        public void OnPageSizeChanged( int PageSize );
    }
}