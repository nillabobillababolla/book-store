using System;
using BookStore.Business.Generic;
using BookStore.Entity;
using BookStore.Entity.Context;

namespace BookStore.Business.Services
{
    public class DocumentService : EFRepository<Document>, IDocumentService
    {
        private BookDbContext _context;
        
        public DocumentService(BookDbContext context) : base(context)
        {
            _context = context;
        }

        //TODO: User sistemi yazıldığında CreatedBy ve UpdatedBy field ları doldurulacak.

        public object PostDocument(string contentType, string dbFile, string childPath)
        {
            Document document = new Document();

            document.ContentType = contentType;
            document.FileName = dbFile;
            document.FullPath = childPath;
            document.CreatedBy = "Test: Safa";
            document.CreatedDate = DateTime.Now;

            _context.Document.Add(document);
            _context.SaveChanges();

            return document.Id;
        }
    }
}