public class BookViewService<T>: InMemoryViewService<BookViewModel<T>, T>
    where T: BaseEntity

{
 
    public BookViewService( IBusinessApplicationDesigner provider ): base(provider)
    {
        
    }
}