function BookDetails({ book }) {
if (!book) return null; // Prevent rendering if no book
return (
<div style={{ border: "1px solid #aaa", padding: 12, margin: 8 }}>
<h3>Book Details</h3>
<p><strong>Title:</strong> {book.title}</p>
<p><strong>Author:</strong> {book.author}</p>
<p><strong>Year:</strong> {book.year}</p>
</div>
);
}

export default BookDetails;