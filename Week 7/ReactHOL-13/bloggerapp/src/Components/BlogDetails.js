function BlogDetails({ blog }) {
return blog ? (
<div style={{ border: "1px solid #aaa", padding: 12, margin: 8 }}>
<h3>Blog Details</h3>
<p><strong>Title:</strong> {blog.title}</p>
<p><strong>Author:</strong> {blog.author}</p>
<p><strong>Date:</strong> {blog.date}</p>
</div>
) : null;
}

export default BlogDetails;