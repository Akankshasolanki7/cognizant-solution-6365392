function CourseDetails({ courses }) {
return (
<div style={{ border: "1px solid #aaa", padding: 12, margin: 8 }}>
<h3>Course Details</h3>
{courses && courses.length > 0 ? (
<ul>
{courses.map(course => (
<li key={course.id}>
{course.name} ({course.duration} weeks)
</li>
))}
</ul>
) : (
<p>No courses available.</p>
)}
</div>
);
}

export default CourseDetails;