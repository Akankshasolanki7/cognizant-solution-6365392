import React, { useState } from 'react';
import BookDetails from './Components/BookDetails';
import BlogDetails from './Components/BlogDetails';
import CourseDetails from './Components/CourseDetails';

function App() {
const [showBook, setShowBook] = useState(true);
const [showBlog, setShowBlog] = useState(true);
const [showCourses, setShowCourses] = useState(true);

const book = { title: "React in Action", author: "Mark T.", year: 2018 };
const blog = { title: "Conditional Rendering in React", author: "Jane Doe", date: "2024-07-05" };
const courses = [
{ id: 1, name: "React Basics", duration: 4 },
{ id: 2, name: "Advanced React", duration: 6 },
{ id: 3, name: "React Testing", duration: 3 }
];

function renderSection() {
if (showBook && showBlog && showCourses) {
return <p>All sections are visible.</p>;
} else if (!showBook && !showBlog && !showCourses) {
return <p>No sections are visible.</p>;
} else {
return <p>Some sections are visible.</p>;
}
}

return (
<div style={{ maxWidth: 600, margin: "40px auto" }}>
<h1>Blogger App</h1>
{/* Toggle buttons */}
<div style={{ marginBottom: 20 }}>
<button onClick={() => setShowBook(b => !b)}>
{showBook ? "Hide" : "Show"} Book Details
</button>
<button onClick={() => setShowBlog(b => !b)} style={{ marginLeft: 8 }}>
{showBlog ? "Hide" : "Show"} Blog Details
</button>
<button onClick={() => setShowCourses(b => !b)} style={{ marginLeft: 8 }}>
{showCourses ? "Hide" : "Show"} Course Details
</button>
</div>
{}
{renderSection()}
{}
{showBook && <BookDetails book={book} />}
{showBlog ? <BlogDetails blog={blog} /> : null}
{}
{showCourses ? <CourseDetails courses={courses} /> : <p>Courses are hidden.</p>}
</div>
);
}

export default App;